using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject hitbox;
    private Rigidbody2D rb;
    public LayerMask floorLayer;
    public Transform floorCheck;
    public float floorCheckRadius = 0.1f;
    private bool isGrounded = false;
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
        CheckGrounded();


        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        animator.SetBool("isWalking", moveX != 0);

        if (moveX > 0 && !facingRight) Flip();
        if (moveX < 0 && facingRight) Flip();

        // Wジャンプ
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Space攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }


        if (!isGrounded)
        {
            if (rb.linearVelocity.y > 0.01f)
            {
                animator.Play("JumpUp");
            }
            else if (rb.linearVelocity.y < 0.5f)
            {
                animator.Play("JumpFall");
            }
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            if (!isGrounded)
            {
                animator.SetTrigger("JumpLand");
            }
            isGrounded = true;
        }
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




}
