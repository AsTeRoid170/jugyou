using UnityEngine;

public class FallFloor : MonoBehaviour
{
    bool floor_touch; //���ɐG�ꂽ���̔���`
    public float downSpeed = -1; //������X�s�[�h
    float fallCount; //����������܂ł̎���
    Rigidbody2D rb; //Rigidbody�̐錾
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody�̎擾
        fallCount = 0; //fullCpunt��������
    }

    // Update is called once per frame
    void Update()
    {
        //���ɐG�ꂽ��
        if (floor_touch == true)
        {
            //fallCount��1�b�����₷�B
            fallCount += Time.deltaTime;
            //DownStart�֐����g��
            DownStart();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //�v���C���[�^�O���t���Ă���I�u�W�F�N�g�ɓ���������
        if (col.gameObject.tag == "Player")
        {
            fallCount = 0; //fallCount��������
            floor_touch = true; //floor_touch��true�ɂ���B
        }
        else
        {
            floor_touch = false;
        }
    }
    void DownStart()
    {
        //fallCount�����b����������
        if (fallCount >= 2.0f)
        {
            transform.Translate(0, downSpeed, 0); //Y���W��downSpeed���ς���B
        }
    }
}
