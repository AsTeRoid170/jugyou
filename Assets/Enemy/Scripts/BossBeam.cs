using UnityEngine;

public class BossBeam : MonoBehaviour
{
    [SerializeField] float speed = 10f;                 // �e��
    [SerializeField] int AttackPower = 15;              // �U����
    GameObject player;                                  // �v���C���[�̂���Ƃ���Ɍ���
    Vector2 targetPosition;                             // �v���C���[�̈ʒu
    Vector2 direction;                                  // �v���C���[�Ƃ̋���
    [SerializeField] float Interval = 10.0f;            // ������Ă��牽�b��ɏ�����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // �v���C���[�̈ʒu���擾
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            targetPosition = player.transform.position;
        }
        direction = (targetPosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

    }

    // Update is called once per frame
    void Update()
    {
        // �ړ�
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Destroy(gameObject, Interval);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // enemy�ɓ�����Ȃ� ����ȊO�ɓ��������������
        if (collision.gameObject.tag != "enemy")
        {
            // �v���C���[�ɓ���������_���[�W��^����
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(AttackPower);
            }

            Destroy(gameObject);
        }

    }
}
