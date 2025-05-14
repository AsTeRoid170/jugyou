using UnityEngine;

public class FloatFloor : MonoBehaviour
{
    //•Ï”’è‹`
    private Rigidbody2D rb;
    private Vector2 defaultpass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
    }

    void Update()
    {
        //XÀ•W‚Ì‚İ‰¡ˆÚ“®
        rb.MovePosition(new Vector2(defaultpass.x + Mathf.PingPong(Time.time, 6), defaultpass.y));
    }

}
