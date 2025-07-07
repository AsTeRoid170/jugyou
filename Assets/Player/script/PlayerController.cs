using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    public GameObject hitbox;

    // 地面判定用
    public LayerMask floorLayer;
    public Transform floorCheck;
    public float floorCheckRadius = 0.1f;

    private bool isGrounded = false;
    private bool facingRight = true;

    private Rigidbody2D rb;
    private Animator animator;

    private PlayerStatus status; // ステータスのいじるスクリプトを参照する

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitbox.SetActive(false);

        // 同じGameObjectまたは親子関係にあるPlayerStatusを取得
        status = GetComponent<PlayerStatus>();
        if (status == null)
        {
            Debug.LogWarning("PlayerStatus が見つかりませんでした");
        }
    }

    void Update()
    {
        CheckGrounded();

        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        if (status != null)
        {
            // ステータスを参照して移動速度を設定
            rb.linearVelocity = new Vector2(moveX * status.moveSpeed, rb.linearVelocity.y);
        }

        animator.SetBool("isWalking", moveX != 0);

        if (moveX > 0 && !facingRight) Flip();
        if (moveX < 0 && facingRight) Flip();

        // ジャンプ（Wキー）※地面にいる時のみ
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && status != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, status.jumpForce);
        }

        // 攻撃（Spaceキー）
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("攻撃トリガー発火！");
            animator.SetTrigger("attack");
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool isAttacking = stateInfo.IsTag("Attack"); // 攻撃ステートに "Attack" タグを設定しておく


        animator.SetFloat("VelocityY", rb.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }


    void CheckGrounded()
    {
        Collider2D hit = Physics2D.OverlapCircle(floorCheck.position, floorCheckRadius, floorLayer);
        isGrounded = hit != null;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // アニメーションイベントから呼ばれる攻撃処理
    public void Attack()
    {
        Debug.Log("攻撃");

        StartCoroutine(EnableSwordHitbox());
    }

    IEnumerator EnableSwordHitbox()
    {
        // 攻撃ヒットボックスの位置を向きに応じて調整
        Vector3 offset = new Vector3(1.5f, 0, 0);
        hitbox.transform.localPosition = offset;

        // ヒットボックスの横幅をパワーで変える（オプション）
        //if (status != null)
        //{
        //    hitbox.transform.localScale = new Vector3(status.power, 1f, 1f);
        //}

        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(false);
    }
}
