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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyCol = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDirectionFlg)
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
        // Ç±Ç±ÇÃ-0.5Çç∂âEÇÃå¸Ç´Ç≈-ÇäOÇ∑(ïœêîÇópà”)
        Vector2 origin = new Vector2(enemyRb.transform.position.x + forwardDistance, enemyRb.transform.position.y + footDistance);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, rayDistance);

        Debug.DrawLine(origin, origin + direction * rayDistance, Color.red);

        if(hit.collider == null)
        {
            Flip();
        }
        
    }

    private void Flip()
    {
        enemyDirectionFlg = !enemyDirectionFlg;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  // Xé≤Ç≈îΩì]
        transform.localScale = localScale;
        forwardDistance *= -1;
    }

}
