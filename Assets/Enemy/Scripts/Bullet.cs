using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;                 // 弾速
    [SerializeField] int AttackPower = 15;              // 攻撃力
    GameObject player;                                  // プレイヤーのいるところに撃つ
    Vector2 targetPosition;                             // プレイヤーの位置
    Vector2 direction;                                  // プレイヤーとの距離
    [SerializeField] float Interval = 10.0f;            // 放たれてから何秒後に消える

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // プレイヤーの位置を取得
        player = GameObject.FindWithTag("Player");
        if(player != null)
        {
            targetPosition = player.transform.position;
        }
        direction = (targetPosition - (Vector2)transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject, Interval);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // enemyに当たらない それ以外に当たったら消える
        if(collision.gameObject.tag != "enemy")
        {
            // プレイヤーに当たったらダメージを与える
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(AttackPower);
            }

            Destroy(gameObject);
        }
        
    }
}
