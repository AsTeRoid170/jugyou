using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{

    Rigidbody2D EnemyRb;
    [SerializeField] float MoveSpeed = 5f;
    bool EnemyDirectionFlg;                                          // �I�u�W�F�N�g���ǂ����̕����ɐi�ނ����f���� true����

    Vector2 DirectionDown = Vector2.down;                            // Ray���������ɔ�΂�
    [SerializeField] float RayDistance = 0.3f;                                        //Ray�̔򋗗�
    Vector2 origin;
    Bounds bounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        EnemyDirectionFlg = true;
    }

    // Update is called once per frame
    void Update()
    {

        bounds = GetComponent<Collider2D>().bounds;

        if (EnemyDirectionFlg)
        {
            transform.position += Vector3.left * Time.deltaTime * MoveSpeed;
            origin = new Vector2(bounds.min.x, bounds.min.y);
        }
        else
        {
            transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
            origin = new Vector2(bounds.max.x, bounds.min.y);
        }
        
        Vector2 bottomLeft = bounds.min;

        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, RayDistance);
        
        Debug.DrawLine(origin, origin + DirectionDown * RayDistance, Color.red);
        

        if(hit.collider == null)
        {
            Flip();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "enemy")
        {
            Flip();
        }
    }

    // ���]
    private void Flip()
    {
        EnemyDirectionFlg = !EnemyDirectionFlg;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  
        transform.localScale = localScale;
    }

}
