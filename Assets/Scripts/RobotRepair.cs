using UnityEngine;
using static PickupItem;

public class RobotRepair : MonoBehaviour
{
    public bool isRepaired = false;

    [SerializeField] private PartType partType;
    [SerializeField] private int partID;

    public bool TryRepair(GameObject carriedObject)
    {
        if (isRepaired)
        {
            Debug.Log("Robot ju¿ naprawiony");
            return false;
        }

        PickupItem item = carriedObject.GetComponent<PickupItem>();

        if (item == null)
        {
            Debug.Log("To nie jest czêœæ robota");
            return false;
        }

        if (item.partType == partType && item.partID == partID)
        {
            Debug.Log("Robot naprawiony!");

            isRepaired = true;

            Destroy(carriedObject);
            return true;
        }
        else
        {
            Debug.Log("Z³a czêœæ! Oczekiwano: " + partType + " " + partID);
            return false;
        }
    }
}