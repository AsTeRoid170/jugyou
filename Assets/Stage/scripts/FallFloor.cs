using UnityEngine;

public class FallFloor : MonoBehaviour
{
    bool floor_touch; //床に触れたかの判定`
    public float downSpeed = -1; //落ちるスピード
    float fallCount; //床が落ちるまでの時間
    float x;
    float y;
    float z;
    Rigidbody2D rb; //Rigidbodyの宣言
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbodyの取得
        fallCount = 0; //fullCpuntを初期化
        x = this.transform.position.x;
        y = this.transform.position.y;
        z = this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //床に触れたら
        if (floor_touch == true)
        {
            //fallCountを1秒ずつ増やす。
            fallCount += Time.deltaTime;
            //DownStart関数を使う
            DownStart();
            //if(transform.position.y > y + 100 || transform.position.y < y-100)
            if(fallCount >= 5)
            {
                fallCount = 0;
                floor_touch = false;
                transform.position = new Vector3(x, y, z);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        //プレイヤータグが付いているオブジェクトに当たったら
        if (col.gameObject.tag == "Player")
        {
            fallCount = 0; //fallCountを初期化
            floor_touch = true; //floor_touchをtrueにする。

        }
    }
    void DownStart()
    {
        //fallCountが何秒かたったら
        if (fallCount >= 2.0f)
        {
            transform.Translate(0, downSpeed, 0); //Y座標をdownSpeedずつ変える。
        }
    }
}
