using UnityEngine;

public class Leverscript : MonoBehaviour
{
    SpriteRenderer sr;

    public bool state = false;

    [SerializeField] Color offColor = Color.red;
    [SerializeField] Color onColor = Color.green;

    [SerializeField] private DoorScript linkedDoor;

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
        }
    }
    public void ToggleLever()
    {
        state = !state;
        Debug.Log("Lever state: " + state); //debug

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
            sr.color = onColor;
        else
            sr.color = offColor;

        // tylko dodatkowe rozjaœnienie jeœli gracz blisko
        if (playerNearby)
        {
            sr.color *= 1.2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
