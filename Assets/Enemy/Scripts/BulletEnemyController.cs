using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;            // �e ���ˈʒu
    [SerializeField] GameObject bullet;                 // �e
    [SerializeField] float Interval = 5.0f;             // ���ˊԊu
    GameObject player;                                  // �v���C���[�̈ʒu�ɂ���Č�����ς���

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("Shoot", 0.1f, Interval);       // ���Ԋu�Œe������
        
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̕�������
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));


            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }

        
    }

    // �e�𐶐�����
    private void Shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
    }
}
