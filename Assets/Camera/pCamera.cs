using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class pCamera : MonoBehaviour
{
    
    public GameObject player;

    private float playerX = 8.0f; //playerのX座標取得
    private float playerY = -5.0f; //playerのY座標取得
    private float cameraZ = 0.0f;  //カメラのZ座標取得
    private float offsetX = 0.0f;  //キャラとカメラのX座標オフセット
    private float offsetY = 0.0f;  //キャラとカメラのY座標オフセット

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // カメラとplayerのX,Y軸の差をオフセットとして取り込む
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;

        //Z軸は操作しないので初期位置を取得
        cameraZ = transform.position.z;

        //playerの初期のX,Y軸を取得
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        //playerが移動しているときだけX,Y座標を取得
        if (playerX < player.transform.position.x|| playerX > player.transform.position.x)
            playerX = player.transform.position.x;
        if (playerY < player.transform.position.y || playerY > player.transform.position.y)
            playerY = player.transform.position.y;

        //playerとのオフセットを計算して座標移動
        transform.position = new Vector3(playerX + offsetX, playerY + offsetY, cameraZ);
        
    }
}
