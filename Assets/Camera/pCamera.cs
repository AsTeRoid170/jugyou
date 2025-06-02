using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class pCamera : MonoBehaviour
{
    
    public GameObject player;

    private float playerX = 8.0f; //player��X���W�擾
    private float playerY = -5.0f; //player��Y���W�擾
    private float cameraZ = 0.0f;  //�J������Z���W�擾
    private float offsetX = 0.0f;  //�L�����ƃJ������X���W�I�t�Z�b�g
    private float offsetY = 0.0f;  //�L�����ƃJ������Y���W�I�t�Z�b�g

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // �J������player��X,Y���̍����I�t�Z�b�g�Ƃ��Ď�荞��
        offsetX = transform.position.x - player.transform.position.x;
        offsetY = transform.position.y - player.transform.position.y;

        //Z���͑��삵�Ȃ��̂ŏ����ʒu���擾
        cameraZ = transform.position.z;

        //player�̏�����X,Y�����擾
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
        //player���ړ����Ă���Ƃ�����X,Y���W���擾
        if (playerX < player.transform.position.x|| playerX > player.transform.position.x)
            playerX = player.transform.position.x;
        if (playerY < player.transform.position.y || playerY > player.transform.position.y)
            playerY = player.transform.position.y;

        //player�Ƃ̃I�t�Z�b�g���v�Z���č��W�ړ�
        transform.position = new Vector3(playerX + offsetX, playerY + offsetY, cameraZ);
        
    }
}
