using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int AttackPower = 15;      // �U����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Player�ɓ���������_���[�W��^����
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy�U��");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                Debug.Log("nemy�U��");
                player.TakeDamage(AttackPower);
            }
        }
    }
}
