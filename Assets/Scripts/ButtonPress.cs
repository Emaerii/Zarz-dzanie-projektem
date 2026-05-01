using UnityEngine;

public class PressureButton : MonoBehaviour
{
    [SerializeField] private DoorScript linkedDoor;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite normalSprite;

    private SpriteRenderer sr;

    private int objectsOnButton = 0;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            objectsOnButton++;

            UpdateState();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody != null)
        {
            objectsOnButton--;

            UpdateState();
        }
    }

    void UpdateState()
    {
        bool isPressed = objectsOnButton > 0;

        if (linkedDoor != null)
        {
            linkedDoor.UpdateDoor(!isPressed);
        }

        if (sr != null)
        {
            sr.sprite = !isPressed ? pressedSprite : normalSprite;
        }
    }
}