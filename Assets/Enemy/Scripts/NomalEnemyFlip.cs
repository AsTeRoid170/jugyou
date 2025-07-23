using UnityEngine;

public class NomalEnemyFlip : MonoBehaviour
{
    EnemyMove EnemyMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyMove = GetComponentInParent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            EnemyMove.Flip();
        }
        
    }
}
