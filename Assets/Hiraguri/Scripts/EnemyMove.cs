using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D EnemyRb;
    [SerializeField] float MoveSpeed = 5f;
    bool EnemyDirectionFlg;                                          // オブジェクトがどっちの方向に進むか判断する trueが左

    Vector2 DirectionDown = Vector2.down;                            // Rayを下向きに飛ばす
    [SerializeField] float RayDistance = 0.3f;                                        //Rayの飛距離
    [SerializeField] float ForwardDistance = -0.5f;                  //Rayのスタート位置 x 最初は左向きだから-
    [SerializeField] float FootDistance = -0.7f;                     //Rayのスタート位置 y サイズによって調整が必要

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemyDirectionFlg = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDirectionFlg)
        {
            transform.position += Vector3.left * Time.deltaTime * MoveSpeed;
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
        }
        
        Vector2 origin = new Vector2(
            EnemyRb.transform.position.x + ForwardDistance, EnemyRb.transform.position.y +FootDistance);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, RayDistance);

        Debug.DrawLine(origin, origin + DirectionDown * RayDistance, Color.red);

        if(hit.collider == null)
        {
            Flip();
        }
        
    }

    // 反転
    private void Flip()
    {
        EnemyDirectionFlg = !EnemyDirectionFlg;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  
        transform.localScale = localScale;
        ForwardDistance *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "enemy")
        {
            Flip();
        }
    }

}
