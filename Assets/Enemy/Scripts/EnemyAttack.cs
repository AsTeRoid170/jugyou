using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int AttackPower = 15;      // UŒ‚—Í

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player‚É“–‚½‚Á‚½‚çƒ_ƒ[ƒW‚ğ—^‚¦‚é
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("EnemyUŒ‚");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("nemyUŒ‚");
                player.TakeDamage(AttackPower);
            }
        }
    }
}
