using UnityEngine;

public class NomalEnemyFlip : MonoBehaviour
{
    EnemyMove EnemyMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyMove = GetComponentInParent<EnemyMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player") // プレイヤー以外に当たったら反転
        {
            EnemyMove.Flip();
        }
        
    }
}
