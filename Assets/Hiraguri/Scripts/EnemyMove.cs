using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRb;
    Collider2D enemyCol;
    [SerializeField] float moveSpeed = 5;
    Vector2 direction = Vector2.down;
    float rayDistance = 0.3f;
    float forwardDistance = -0.5f;
    float footDistance = -0.7f;
    bool enemyDirectionFlg = true;
    [SerializeField] float maxSpeed = 5;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        /*if (enemyDirectionFlg)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

        Vector2 origin = new Vector2(enemyRb.transform.position.x + forwardDistance, enemyRb.transform.position.y + footDistance);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance);

        Debug.DrawLine(origin, origin + direction * rayDistance, Color.red);

        if(hit.collider == null)
        {
            Flip();
        }*/
        
    }

    private void Move()
    {
        
        Vector2 origin = new Vector2(enemyRb.position.x, enemyRb.position.y - enemyCol.bounds.extents.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 0.1f);

        if (hit.collider != null)
        {
            
            Vector2 groundNormal = hit.normal;

            
            Vector2 moveDirection = new Vector2(groundNormal.y, -groundNormal.x).normalized;

            
            enemyRb.linearVelocity = moveDirection * moveSpeed;
        }
        else
        {
            
            enemyRb.linearVelocity = Vector2.zero;
        }

        // 向きの反転処理
        if (enemyDirectionFlg && enemyRb.linearVelocity.x < 0)
        {
            Flip();
        }
        else if (!enemyDirectionFlg && enemyRb.linearVelocity.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        enemyDirectionFlg = !enemyDirectionFlg;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // X���Ŕ��]
        transform.localScale = localScale;
        forwardDistance *= -1;
    }

}
