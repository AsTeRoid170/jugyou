using UnityEngine;

public class NeedleDamege : MonoBehaviour
{
    [SerializeField] int AttackPower = 10;      // �U����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player�ɓ���������_���[�W��^����
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("�Ƃ��ɐڐG");
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            if (player != null)
            {
                //Debug.Log(collision.gameObject.name);
                player.TakeDamage(AttackPower);
            }
        }
    }
}
