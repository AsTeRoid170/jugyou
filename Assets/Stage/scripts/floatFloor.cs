using UnityEngine;

public class FloatFloor : MonoBehaviour
{
    //変数定義
    private Rigidbody2D rb;
    private Vector2 defaultpass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
    }

    void Update()
    {
        //X座標のみ横移動
        rb.MovePosition(new Vector2(defaultpass.x + Mathf.PingPong(Time.time, 6), defaultpass.y));
    }

}
