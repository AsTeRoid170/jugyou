using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 5f;                           // �ړ��X�s�[�h
    bool enemyDirectionFlg;                                          // �I�u�W�F�N�g���ǂ����̕����ɐi�ނ����f���� true����

    // Ray�ŊR�[�ɂ��邩���f�����]
    Vector2 DirectionDown = Vector2.down;                            // Ray���������ɔ�΂�
    [SerializeField] float RayDistance = 0.3f;                       // Ray�̔򋗗�
    Vector2 origin;                                                  // Ray���ˈʒu
    Bounds bounds;                                                   // �I�u�W�F�N�g�Ɏ΂߉��̈ʒu���擾����p

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyDirectionFlg = true;
    }

    // Update is called once per frame
    void Update()
    {

        bounds = GetComponent<Collider2D>().bounds;

        if (enemyDirectionFlg)
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
        enemyDirectionFlg = !enemyDirectionFlg;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;  
        transform.localScale = localScale;
    }

}
