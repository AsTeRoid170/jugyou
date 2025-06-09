using UnityEngine;

public class pCamera : MonoBehaviour
{
    public GameObject player;

    public float xOffset = 6.0f;      // �v���C���[�̍����z�u
    public float yFixed = 0.0f;        // �Œ肷��Y���W�i�n�ʂ���̍����j
    public float zoomOut = 5.0f;       // �J�����̃Y�[���A�E�g�iorthographicSize�j

    private Camera cam;

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
    }

    void LateUpdate()
    {
        if (player == null) return;

        // X���̓v���C���[�ɒǏ]�AY���͌Œ�AZ��-10��2D
        Vector3 newCamPos = new Vector3(player.transform.position.x + xOffset, yFixed, -10f);
        transform.position = newCamPos;
    }
}