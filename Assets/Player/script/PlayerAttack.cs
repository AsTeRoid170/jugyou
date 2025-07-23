using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        // �v���C���[��PlayerStatus���擾�i�e�I�u�W�F�N�g�ȂǓK�X�ύX�j
        playerStatus = GetComponentInParent<PlayerStatus>();

        if (playerStatus == null)
        {
            Debug.LogWarning("PlayerStatus ��������܂���ł���");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null && playerStatus != null)
            {
                Debug.Log("You way");
                int damage = playerStatus.GetPower();  // �U���͂��擾
                enemy.TakeDamage(damage);
            }
        }
    }
}
