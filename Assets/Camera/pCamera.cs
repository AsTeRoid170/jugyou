using UnityEngine;

public class pCamera : MonoBehaviour
{
    public GameObject player;

    public float xOffset = 6.0f;      // プレイヤーの左寄り配置
    public float yFixed = 0.0f;        // 固定するY座標（地面からの高さ）
    public float zoomOut = 5.0f;       // カメラのズームアウト（orthographicSize）

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

        // X軸はプレイヤーに追従、Y軸は固定、Zは-10で2D
        Vector3 newCamPos = new Vector3(player.transform.position.x + xOffset, yFixed, -10f);
        transform.position = newCamPos;
    }
}