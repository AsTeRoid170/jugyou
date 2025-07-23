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
        if(collision.tag != "Player") // �v���C���[�ȊO�ɓ��������甽�]
        {
            EnemyMove.Flip();
        }
        
    }
}
