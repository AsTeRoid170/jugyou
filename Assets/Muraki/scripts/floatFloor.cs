using UnityEngine;

public class FloatFloor : MonoBehaviour
{
    //�ϐ���`
    private Rigidbody2D rb;
    private Vector2 defaultpass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
    }

    void Update()
    {
        //X���W�̂݉��ړ�
        rb.MovePosition(new Vector2(defaultpass.x + Mathf.PingPong(Time.time, 6), defaultpass.y));
    }

}
