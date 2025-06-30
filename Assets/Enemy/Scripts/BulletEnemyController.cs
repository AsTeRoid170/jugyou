using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;            // �e ���ˈʒu
    [SerializeField] GameObject bullet;                 // �e
    [SerializeField] float Interval = 5.0f;             // ���ˊԊu
    GameObject player;                                  // �v���C���[�̈ʒu�ɂ���Č�����ς���

    Animator animator;                                  // �A�j���[�^�[
    float animatorCount = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        InvokeRepeating("Shoot",0, Interval);       // ���Ԋu�Œe������
        
    }

    // Update is called once per frame
    void Update()
    {
        // �A�j���[�^�[����
        animatorCount += Time.deltaTime;
        if (animatorCount > Interval - 0.35)
        {
            animator.SetTrigger("AttackTrigger");
            animatorCount = 0;
        }

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
