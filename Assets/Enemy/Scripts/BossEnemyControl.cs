using TMPro;
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

    State currState;                                    // 現在の状態
    GameObject player;                                  // プレイヤーの位置で行動を決めたい
    float direction;                                    // プレイヤーとの距離
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
        // playerの位置を取得
        if (player != null)
        {
            playerPosition = player.transform.position;
        }
        direction = Mathf.Abs(playerPosition.x - transform.position.x);
        Debug.Log(direction);

        // plyerのほうを向く
        flip();

        
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
        else if (direction < 8)
        {
            ChangeState(State.Punch);
        }
        // Beamへの切り替え
        else if (direction < 15)
        {
            ChangeState(State.Beam);
        }

        // 行動切り替え
        switch (currState)
        {
            // 待機状態
            case State.Idle:
                BossIdel();
                break;

            // 移動
            case State.Move:
                BossMove();
                break;

            // 攻撃 こぶしを振り下ろす
            case State.Punch:
                BossPunch();
                break;

            // 攻撃 ビーム
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
        // プレイヤーの方を向く
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
