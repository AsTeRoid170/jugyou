using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRb;
    Collider2D enemyCol;
    [SerializeField] float moveSpeed = 5;
    float distance = 0.1f;
    int moveDirection = 1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // ˆÚ“®
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        

        //RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 1);

    }

}
