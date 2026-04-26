
using UnityEngine;

public class DeadlyObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}
