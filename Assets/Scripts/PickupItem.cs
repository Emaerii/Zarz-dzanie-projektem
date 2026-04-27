using UnityEngine;


public class PickupItem : MonoBehaviour
{
    public void PickUp()
    {
        Debug.Log("Podniesiono obiekt");

        gameObject.SetActive(false);

        // póŸniej zamiast tego:
        // dodaæ do inventory
    }
}