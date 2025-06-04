using TMPro;
using UnityEngine;

public class BossEnemyControl : MonoBehaviour
{

    // ��Ԃ�\���X�e�[�^�X
    private enum State
    {
        Idle,           // �ҋ@���
        Move,           // �ړ�
        Punch,          // �U���@�p���`
        Beam            // �U���@�r�[��
    }

    State currState;                                    // ���݂̏��
    GameObject player;                                  // �v���C���[�̈ʒu�ōs�������߂���
    float direction;                                    // �v���C���[�Ƃ̋���
    Vector2 playerPosition;                             //
    Vector2 startPosition;
    [SerializeField] float punchDelay = 5.0f;
    [SerializeField] float beamDelay = 5.0f;
    [SerializeField] GameObject beam;
    [SerializeField] GameObject beamPoint;
    float beamDelayTime;
    float punchDelayTime;
    //[SerializeField] float returnDirection = 16f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startPosition = transform.position;
        beamDelayTime = beamDelay;
        currState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // player�̈ʒu���擾
        if (player != null)
        {
            playerPosition = player.transform.position;
        }
        direction = Mathf.Abs(playerPosition.x - transform.position.x);
        Debug.Log(direction);

        // plyer�̂ق�������
        flip();

        
        // Idle�ւ̐؂�ւ�
        if (player == null)
        {
            ChangeState(State.Idle);
        }
        // Move�ւ̐؂�ւ� 
        else if (player.tag == "enemy")
        {
            ChangeState(State.Move);
        }
        // Punch�ւ̐؂�ւ�
        else if (direction < 8)
        {
            ChangeState(State.Punch);
        }
        // Beam�ւ̐؂�ւ�
        else if (direction < 15)
        {
            ChangeState(State.Beam);
        }

        // �s���؂�ւ�
        switch (currState)
        {
            // �ҋ@���
            case State.Idle:
                BossIdel();
                break;

            // �ړ�
            case State.Move:
                BossMove();
                break;

            // �U�� ���Ԃ���U�艺�낷
            case State.Punch:
                BossPunch();
                break;

            // �U�� �r�[��
            case State.Beam:
                BossBeam();
                break;
        }
    }

    private void ChangeState(State newState)
    {
        currState = newState;
    }

    private void BossIdel()
    {

    }
    private void BossMove()
    {
        
    }

    private void BossPunch()
    {
        //Debug.Log("punch");
    }

    private void BossBeam()
    {
        if (beamDelayTime > beamDelay)
        {

            Instantiate(beam, beamPoint.transform.position, Quaternion.identity);
            beamDelayTime = 0f;
        }
        else
        {
            beamDelayTime += Time.deltaTime;
        }
        
    }

    private void flip()
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
}
