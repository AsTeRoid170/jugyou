using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class BossEnemyController : MonoBehaviour
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
    Vector2 playerPosition;                             // プレイヤーの位置

    // move用
    [SerializeField] float moveSpeed = 2f;                  // 歩くスピード
    [SerializeField] float moveRange = 10f;                 // プレイヤーがどれくらいの距離で歩くか
    float moveDirection = 1;                                // 歩く距離
    float timer;                                            // 歩く時間時間制御用
    [SerializeField] float changeDirectionInterval = 1f;    // 歩く時間

    // punch用
    [SerializeField] float punchDelay = 5.0f;               // 何秒間隔でパンチするか
    [SerializeField] float punchRange = 7f;                 // プレイヤーがどれくらいの距離でパンチするか
    [SerializeField] GameObject punchHitBox;                // パンチの当たり判定
    float punchDelayTime;                                   // ディレイカウント用

    // beam用
    [SerializeField] float beamRange = 15f;                 // どれくらいの距離でビームを撃つか
    [SerializeField] float beamDelay = 5.0f;                // ビーム間隔
    [SerializeField] GameObject beam;                       // ビームオブジェクト
    [SerializeField] GameObject beamPoint;                  // ビーム発射位置
    float beamDelayTime;                                    // ディレイカウント用              

    // アニメーター
    Animator animatorSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // playerを見つける
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

        // playerの位置を取得
        if (player != null)
        {
            playerPosition = player.transform.position;
        }
        // playerとの距離を計算
        direction = Mathf.Abs(playerPosition.x - transform.position.x);
        //Debug.Log(direction);

        // plyerのほうを向く
        flip();

        // Idleへの切り替え
        if (player == null)
        {
            ChangeState(State.Idle);
        }
        // Punchへの切り替え
        else if (direction < punchRange)
        {
            ChangeState(State.Punch);
        }
        // Moveへの切り替え 
        else if (direction < moveRange )
        {
            ChangeState(State.Move);
        }
        // Beamへの切り替え
        else if (direction < beamRange)
        {
            ChangeState(State.Beam);
        }

        // パンチ判定が出しっぱなしになることを避けるため
        if (currState != State.Punch)
        {
            punchHitBox.SetActive(false);
        }

        // 行動切り替え
        switch (currState)
        {
            // 待機状態
            case State.Idle:
               // animatorSprite.SetBool("Move", false);
                BossIdel();
                break;

            // 移動
            case State.Move:
                BossMove();
                break;

            // 攻撃 こぶしを振り下ろす
            case State.Punch:
                
                BossPunch();
                // 攻撃判定が出ている最中は動かない
                if(!punchHitBox.activeInHierarchy)
                {
                    BossMove();
                }
                break;

            // 攻撃 ビーム
            case State.Beam:
                BossMove();
                BossBeam();
                break;
        }
    }

    // Stateの変更
    private void ChangeState(State newState)
    {
        currState = newState;
    }

    private void BossIdel()
    {
        // 何もしない
        animatorSprite.SetTrigger("IdelTrigger");
    }

    // 右往左往する
    private void BossMove()
    {
        if (player != null)
        {
            //animatorSprite.SetBool("Move", true);
            animatorSprite.SetTrigger("MoveTrigger");
            transform.Translate(Vector2.right * moveDirection * moveSpeed * Time.deltaTime);
            // 一定時間ごとに方向を変える
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                moveDirection *= -1f; // 向きを反転
                timer = changeDirectionInterval + Random.Range(-0.5f, 0.5f); // 少しバラつかせる
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
            // 一定時間当たり判定を出す
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

    // プレイヤーの方を向く
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
