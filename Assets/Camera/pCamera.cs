using UnityEngine;

public class pCamera : MonoBehaviour
{
    public GameObject player;

    public float xOffset = 6.0f;         // �v���C���[����⍶���ɔz�u
    public float yFixed = 0.0f;          // �ʏ�̃J����Y�ʒu�i�n�ʁj
    public float upperYThreshold = 2.5f; // �v���C���[�����̍�������ɍs���ƃJ�������Ǐ]
    public float camYSpeed = 5.0f;       // Y�����̕�ԃX�s�[�h
    public float zoomOut = 5.0f;         // �J�����̃Y�[���A�E�g

    private Camera cam;
    private float currentY;              // ���݂̃J����Y�ʒu

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        cam = GetComponent<Camera>();
        if (cam != null && cam.orthographic)
        {
            cam.orthographicSize = zoomOut;
        }

        currentY = yFixed;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float targetY = yFixed;

        if (player.transform.position.y > upperYThreshold)
        {
            // �v���C���[����ɍs���������ꍇ�́A�J�������ǂ�������
            targetY = player.transform.position.y;
        }

        // �J����Y���Ԃ��ăX���[�Y�ɏ㉺�ړ�
        currentY = Mathf.Lerp(currentY, targetY, Time.deltaTime * camYSpeed);

        // �J�����ʒu���X�V
        Vector3 newCamPos = new Vector3(player.transform.position.x + xOffset, currentY, -10f);
        transform.position = newCamPos;
    }
}
