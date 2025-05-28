using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject hitbox;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitbox.SetActive(false);
    }

    void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (moveX > 0)
        {
            transform.localScale = new Vector3((float)0.75, (float)0.8, 1);  // 右向き
            facingRight = true;
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3((float)-0.75, (float)0.8, 1); // 左向きに反転
            facingRight = false;
        }

        // Wジャンプ
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Space攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    // Animation Event から呼ばれる
    public void Attack()
    {
        Debug.Log("攻撃");
        StartCoroutine(EnableSwordHitbox());
    }

    IEnumerator EnableSwordHitbox()
    {
        // 向きによってヒットボックスの位置を変更
        Vector3 offset = new Vector3(facingRight ? 1.5f : 2.5f, 0, 0); // X方向に左右移動
        hitbox.transform.localPosition = offset;


        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 接触が終了したら地面から離れたと判断
        isGrounded = false;
    }
}
