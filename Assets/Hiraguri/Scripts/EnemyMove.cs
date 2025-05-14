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
    [SerializeField] float ForwardDistance = -0.5f;                  //Ray�̃X�^�[�g�ʒu x �ŏ��͍�����������-
    [SerializeField] float FootDistance = -0.7f;                     //Ray�̃X�^�[�g�ʒu y �T�C�Y�ɂ���Ē������K�v

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

    // ���]
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
