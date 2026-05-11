using UnityEngine;
using UnityEngine.Pool;

public class DoorScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Collider2D doorCollider;

  
    [SerializeField] private Sprite closed;
    [SerializeField] private Sprite open;

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
        sr.sprite = open;

        if (doorCollider != null)
            doorCollider.enabled = false;

        // póŸniej tutaj animacja otwierania
        // DoorAnimator.SetTrigger("Open");
    }

    void CloseDoor()
    {
        sr.sprite = closed;

        if (doorCollider != null)
            doorCollider.enabled = true;


        // póŸniej animacja zamykania
        // DoorAnimator.SetTrigger("Close");
    }
}