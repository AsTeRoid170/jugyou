using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class BossEnemyController : MonoBehaviour
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
    Vector2 playerPosition;                             // �v���C���[�̈ʒu

    // move�p
    [SerializeField] float moveSpeed = 2f;                  // �����X�s�[�h
    [SerializeField] float moveRange = 10f;                 // �v���C���[���ǂꂭ�炢�̋����ŕ�����
    float moveDirection = 1;                                // ��������
    float timer;                                            // �������Ԏ��Ԑ���p
    [SerializeField] float changeDirectionInterval = 1f;    // ��������

    // punch�p
    [SerializeField] float punchDelay = 5.0f;               // ���b�Ԋu�Ńp���`���邩
    [SerializeField] float punchRange = 7f;                 // �v���C���[���ǂꂭ�炢�̋����Ńp���`���邩
    [SerializeField] GameObject punchHitBox;                // �p���`�̓����蔻��
    float punchDelayTime;                                   // �f�B���C�J�E���g�p

    // beam�p
    [SerializeField] float beamRange = 15f;                 // �ǂꂭ�炢�̋����Ńr�[��������
    [SerializeField] float beamDelay = 5.0f;                // �r�[���Ԋu
    [SerializeField] GameObject beam;                       // �r�[���I�u�W�F�N�g
    [SerializeField] GameObject beamPoint;                  // �r�[�����ˈʒu
    float beamDelayTime;                                    // �f�B���C�J�E���g�p              

    // �A�j���[�^�[
    Animator animatorSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // player��������
        player = GameObject.FindWithTag("Player");
        timer = changeDirectionInterval;
        punchDelayTime = punchDelay;
        beamDelayTime = beamDelay;
        currState = State.Idle;
        animatorSprite = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // player�̈ʒu���擾
        if (player != null)
        {
            playerPosition = player.transform.position;
        }
        // player�Ƃ̋������v�Z
        direction = Mathf.Abs(playerPosition.x - transform.position.x);
        //Debug.Log(direction);

        // plyer�̂ق�������
        flip();

        // Idle�ւ̐؂�ւ�
        if (player == null)
        {
            ChangeState(State.Idle);
        }
        // Punch�ւ̐؂�ւ�
        else if (direction < punchRange)
        {
            ChangeState(State.Punch);
        }
        // Move�ւ̐؂�ւ� 
        else if (direction < moveRange )
        {
            ChangeState(State.Move);
        }
        // Beam�ւ̐؂�ւ�
        else if (direction < beamRange)
        {
            ChangeState(State.Beam);
        }

        // �p���`���肪�o�����ςȂ��ɂȂ邱�Ƃ�����邽��
        if (currState != State.Punch)
        {
            punchHitBox.SetActive(false);
        }

        // �s���؂�ւ�
        switch (currState)
        {
            // �ҋ@���
            case State.Idle:
               // animatorSprite.SetBool("Move", false);
                BossIdel();
                break;

            // �ړ�
            case State.Move:
                BossMove();
                break;

            // �U�� ���Ԃ���U�艺�낷
            case State.Punch:
                
                BossPunch();
                // �U�����肪�o�Ă���Œ��͓����Ȃ�
                if(!punchHitBox.activeInHierarchy)
                {
                    BossMove();
                }
                break;

            // �U�� �r�[��
            case State.Beam:
                BossMove();
                BossBeam();
                break;
        }
    }

    // State�̕ύX
    private void ChangeState(State newState)
    {
        currState = newState;
    }

    private void BossIdel()
    {
        // �������Ȃ�
        animatorSprite.SetTrigger("IdelTrigger");
    }

    // �E����������
    private void BossMove()
    {
        if (player != null)
        {
            //animatorSprite.SetBool("Move", true);
            animatorSprite.SetTrigger("MoveTrigger");
            transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);
            // ��莞�Ԃ��Ƃɕ�����ς���
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                moveDirection *= -1f; // �����𔽓]
                timer = changeDirectionInterval + Random.Range(-0.5f, 0.5f); // �����o��������
            }
        }
    }

    private void BossPunch()
    {
        if(punchDelayTime > punchDelay)
        {
            animatorSprite.SetTrigger("AttackTrigger");
            punchHitBox.SetActive(true);
            punchDelayTime = 0;
        }
        else
        {
            punchDelayTime += Time.deltaTime;
            // ��莞�ԓ����蔻����o��
            if (punchDelayTime > 0.5)
            {
                punchHitBox.SetActive(false);
            }  
        }
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

    // �v���C���[�̕�������
    private void flip()
    {
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
