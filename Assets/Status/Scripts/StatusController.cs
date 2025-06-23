using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusController : MonoBehaviour
{
    // ステータス（初期値：Speed=5, Jump=7, Power=1）
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float power = 1f;

    // UIスライダー（Canvas上から接続）
    public Slider moveSpeedSlider;
    public Slider jumpForceSlider;
    public Slider powerSlider;

    public GameObject hitbox;
    public LayerMask floorLayer;
    public Transform floorCheck;
    public float floorCheckRadius = 0.1f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool facingRight = true;

    private bool initialized = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitbox.SetActive(false);

        // 初期値をSlider側に反映（初期化）
        if (moveSpeedSlider != null) moveSpeedSlider.value = moveSpeed;
        if (jumpForceSlider != null) jumpForceSlider.value = jumpForce;
        if (powerSlider != null) powerSlider.value = power;
    }

    void Update()
    {
        // スライダーの現在値をステータスに反映（リアルタイム）
        if (moveSpeedSlider != null) moveSpeed = moveSpeedSlider.value;
        if (jumpForceSlider != null) jumpForce = jumpForceSlider.value;
        if (powerSlider != null) power = powerSlider.value;

        CheckGrounded();

        float moveX = 0f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);
        animator.SetBool("isWalking", moveX != 0);

        if (moveX > 0 && !facingRight) Flip();
        if (moveX < 0 && facingRight) Flip();

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }

        if (!isGrounded)
        {
            if (rb.linearVelocity.y > 0.01f)
                animator.Play("JumpUp");
            else if (rb.linearVelocity.y < 0.5f)
                animator.Play("JumpFall");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            if (!isGrounded)
                animator.SetTrigger("JumpLand");

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

    public void Attack()
    {
        Debug.Log("攻撃（Power: " + power + "）");
        StartCoroutine(EnableSwordHitbox());
    }

    IEnumerator EnableSwordHitbox()
    {
        Vector3 offset = new Vector3(facingRight ? 1.5f : -1.5f, 0, 0);
        hitbox.transform.localPosition = offset;

        hitbox.transform.localScale = new Vector3(power, 1f, 1f);
        hitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        hitbox.SetActive(false);
    }
}
