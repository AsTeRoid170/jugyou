using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject swordHitbox;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // Wジャンプ
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Space攻撃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    void Attack()
    {
        Debug.Log("攻撃");
        animator.SetTrigger("attack");  // ←アニメーション再生
        StartCoroutine(EnableSwordHitbox());
    }
    IEnumerator EnableSwordHitbox()
    {
        swordHitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        swordHitbox.SetActive(false);
    }
}
