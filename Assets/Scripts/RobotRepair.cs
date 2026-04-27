using UnityEngine;

public class RobotRepair : MonoBehaviour
{
    public bool isRepaired = false;

    [SerializeField] private GameObject requiredPart;

    public void TryRepair(GameObject carriedObject)
    {
        if (isRepaired)
            return;

        if (carriedObject == requiredPart)
        {
            Debug.Log("Robot naprawiony!");

            isRepaired = true;

            Destroy(carriedObject);

            // póŸniej:
            // animacja naprawy
            // zmiana sprite
        }
        else
        {
            Debug.Log("To nie ta czêœæ.");
        }
    }
}