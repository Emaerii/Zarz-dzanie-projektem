using UnityEngine;


public class PickupItem : MonoBehaviour
{
    public enum PartType
    {
        Arm,
        Battery,
        Head
    }

    public int partID;
    public PartType partType;

    public void PickUp()
    {
        Debug.Log("Podniesiono: " + partType + " " + partID);
    }
}