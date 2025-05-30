using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Camera))]
public class pCamera : MonoBehaviour
{
    GameObject playerObj;
    PlayerController2D player;
    Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController2D>();
        playerTransform = playerObj.transform;

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        // 横方向にだけ追従
        transform.position = new Vector3(playerTransform.position.x,
            playerTransform.position.y,transform.position.z);
    }
}
