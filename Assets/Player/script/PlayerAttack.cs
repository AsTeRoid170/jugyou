using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    private PlayerStatus playerStatus;

    void Start()
    {
        // プレイヤーのPlayerStatusを取得（親オブジェクトなど適宜変更）
        playerStatus = GetComponentInParent<PlayerStatus>();

        if (playerStatus == null)
        {
            Debug.LogWarning("PlayerStatus が見つかりませんでした");
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
                int damage = playerStatus.GetPower();  // 攻撃力を取得
                enemy.TakeDamage(damage);
            }
        }
    }
}
