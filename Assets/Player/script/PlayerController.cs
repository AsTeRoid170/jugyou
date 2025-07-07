using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの2D操作（移動・ジャンプ・攻撃）を制御するクラス
/// </summary>
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

    // ステータス（power → jumpForce → moveSpeed の順）
    private PlayerStatus status;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitbox.SetActive(false);

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

        // ステータスから移動速度を取得して移動処理
        if (status != null)
        {
            rb.linearVelocity = new Vector2(moveX * status.moveSpeed, rb.linearVelocity.y);
        }

        animator.SetBool("isWalking", moveX != 0);

        // 左右反転処理
        if (moveX > 0 && !facingRight) Flip();
        if (moveX < 0 && facingRight) Flip();

        // ジャンプ処理（Wキー）※velocityを直接変更
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && status != null)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, status.jumpForce);
        }

        // 攻撃トリガー
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("攻撃トリガー発火！");
            animator.SetTrigger("attack");
        }

        // アニメーション補助情報
        animator.SetFloat("VelocityY", rb.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded);
    }

    /// <summary>
    /// 地面との接触判定
    /// </summary>
    void CheckGrounded()
    {
        Collider2D hit = Physics2D.OverlapCircle(floorCheck.position, floorCheckRadius, floorLayer);
        isGrounded = hit != null;
    }

    /// <summary>
    /// 向きを左右反転
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    /// <summary>
    /// 攻撃アニメーションイベントから呼ばれる処理
    /// </summary>
    public void Attack()
    {
        Debug.Log("攻撃");
        StartCoroutine(EnableSwordHitbox());
    }

    /// <summary>
    /// 一時的にヒットボックスを表示する
    /// </summary>
    IEnumerator EnableSwordHitbox()
    {
        // 反転したときも攻撃判定あり
        Vector3 offset = new Vector3(1.5f, 0, 0);
        hitbox.transform.localPosition = offset;

        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(false);
    }
}