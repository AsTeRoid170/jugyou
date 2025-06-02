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

    State currState;        // ���݂̏��
    GameObject player;      // �v���C���[�̈ʒu�Ȃǂōs�������߂���
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
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
        else if (player.tag == "Player")
        {
            ChangeState(State.Punch);
        }
        // Beam�ւ̐؂�ւ�
        else if (player.tag == "Floor")
        {
            ChangeState(State.Beam);
        }



        // �s���؂�ւ�
        switch (currState)
        {
            // �ҋ@���
            case State.Idle:

                break;

            // �ړ�
            case State.Move:

                break;

            // �U�� ���Ԃ���U�艺�낷
            case State.Punch:

                break;

            // �U�� �r�[��
            case State.Beam:

                break;
        }
    }

    private void ChangeState(State newState)
    {
        currState = newState;
    }
}
