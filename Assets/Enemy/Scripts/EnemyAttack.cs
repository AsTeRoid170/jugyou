using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int AttackPower = 15;      // UΝ

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // PlayerΙ½Α½η_[Wπ^¦ι
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("EnemyU");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("nemyU");
                player.TakeDamage(AttackPower);
            }
        }
    }
}
