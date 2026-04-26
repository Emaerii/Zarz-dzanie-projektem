using UnityEngine;
using UnityEngine.Pool;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D doorCollider;

    [SerializeField] Color openColor = Color.gray;
    [SerializeField] Color closedColor = Color.blue;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
    }

   
    public void UpdateDoor(bool leverState)
    {
        if (leverState)
        {
            Debug.Log("Door got signal: " + leverState);
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        sr.color = openColor;

        if (doorCollider != null)
            doorCollider.enabled = false;

        // póŸniej tutaj animacja otwierania
        // DoorAnimator.SetTrigger("Open");
    }

    void CloseDoor()
    {
        sr.color = closedColor;

        if (doorCollider != null)
            doorCollider.enabled = true;

        // póŸniej animacja zamykania
        // DoorAnimator.SetTrigger("Close");
    }
}