using UnityEngine;

public class NeedleDamege : MonoBehaviour
{
    [SerializeField] int AttackPower = 10;      // UŒ‚—Í

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player‚É“–‚½‚Á‚½‚çƒ_ƒ[ƒW‚ğ—^‚¦‚é
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("‚Æ‚°‚ÉÚG");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                //Debug.Log(collision.gameObject.name);
                player.TakeDamage(AttackPower);
            }
        }
    }
}
