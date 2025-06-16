using UnityEngine;

public class BossPunch : MonoBehaviour
{
    [SerializeField] int damage = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            player.TakeDamage(damage);
        }
    }
}
