using UnityEngine;
using static PickupItem;

public class RobotRepair : MonoBehaviour
{
    public bool isRepaired = false;

    [SerializeField] private PartType partType;
    [SerializeField] private int partID;

    [SerializeField] private Transform targetPoint; // gdzie ma i��
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] float stopDistance = 0.6f;

    private bool isMoving = false;
    private Rigidbody2D rb;

    [SerializeField] private GameObject targetObject;
    public Animator animator;

    private void Awake()
    {
       rb=GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isMoving) return;

        MoveToTarget();
    }

    public bool TryRepair(GameObject carriedObject)
    {
        if (isRepaired)
        {
            Debug.Log("Robot ju� naprawiony");
            return false;
        }

        PickupItem item = carriedObject.GetComponent<PickupItem>();

        if (item == null)
        {
            Debug.Log("To nie jest cz�� robota");
            return false;
        }

        if (item.partType == partType && item.partID == partID)
        {
            Debug.Log("Robot naprawiony!");

            isRepaired = true;
            animator.SetBool("IsRepaired", true);

            Destroy(carriedObject);
            ActivateRobot();

            return true;
        }
        else
        {
            Debug.Log("Z�a cz��! Oczekiwano: " + partType + " " + partID);
            return false;
        }

     }

    void ActivateRobot()
    {
        Debug.Log("Robot startuje!");

        isMoving = true;
        animator.SetBool("IsMoving", true);

        if (rb != null)
            rb.simulated = true;

        // 🔥 ODBLOKOWANIE X
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void MoveToTarget()
    {
        float distance = Vector2.Distance(transform.position, targetPoint.position);
        Debug.Log(distance);

        if (distance < stopDistance)
        {
            ReachedTarget();
        }

        Vector2 direction = (targetPoint.position - transform.position).normalized;

        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);

        
    }

    void ReachedTarget()
    {
        Debug.Log("Robot dotarł");

        isMoving = false;
        animator.SetBool("IsMoving", false);

        rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;

        ActivateTarget();
    }

    void ActivateTarget()
    {
        
        
        // jeśli to dźwignia
        Leverscript lever = targetObject.GetComponent<Leverscript>();
        if (lever != null)
        {
            lever.ToggleLever();
            return;
        }
        else return;

        // jeśli to przycisk (trigger zrobi resztę)
        // robot po prostu stoi na nim
    }
}