using UnityEngine;

public class BossEnemyControl : MonoBehaviour
{

    // 状態を表すステータス
    private enum State
    {
        Idle,           // 待機状態
        Move,           // 移動
        Punch,          // 攻撃　パンチ
        Beam            // 攻撃　ビーム
    }

    State currState;        // 現在の状態
    GameObject player;      // プレイヤーの位置などで行動を決めたい
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // Idleへの切り替え
        if (player == null)
        {
            ChangeState(State.Idle);
        }
        // Moveへの切り替え 
        else if (player.tag == "enemy")
        {
            ChangeState(State.Move);
        }
        // Punchへの切り替え
        else if (player.tag == "Player")
        {
            ChangeState(State.Punch);
        }
        // Beamへの切り替え
        else if (player.tag == "Floor")
        {
            ChangeState(State.Beam);
        }



        // 行動切り替え
        switch (currState)
        {
            // 待機状態
            case State.Idle:

                break;

            // 移動
            case State.Move:

                break;

            // 攻撃 こぶしを振り下ろす
            case State.Punch:

                break;

            // 攻撃 ビーム
            case State.Beam:

                break;
        }
    }

    private void ChangeState(State newState)
    {
        currState = newState;
    }
}
