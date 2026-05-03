using UnityEngine;

public class Leverscript : MonoBehaviour
{
    SpriteRenderer sr;

    public bool state = false;

    private Sprite secondstate; //off w zalozeniu
    private Sprite firststate; //on w zalozeniu

    [SerializeField] private DoorScript linkedDoor;
    public Animator animator;

    bool playerNearby = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }
    void Start()
    {
        if (linkedDoor != null)
        {
            linkedDoor.UpdateDoor(state);
            animator.SetBool("state", state);
        }
    }
    public void ToggleLever()
    {
        state = !state;
        Debug.Log("Lever state: " + state); //debug
        animator.SetBool("state", state);

        UpdateVisual();

        if (linkedDoor != null)
        {
            Debug.Log("Door found, sending signal");
            linkedDoor.UpdateDoor(state);
        } else Debug.Log("No linked door!");
    }

    public void SetPlayerNearby(bool value)
    {
        playerNearby = value;
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (state)
            sr.sprite = firststate;
        else
            sr.sprite = secondstate;

        animator.SetBool("PlayerClose", playerNearby);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
