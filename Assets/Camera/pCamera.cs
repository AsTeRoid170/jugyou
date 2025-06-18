using UnityEngine;

public class pCamera : MonoBehaviour
{
    public GameObject player;

    public float xOffset = 6.0f;         // プレイヤーをやや左寄りに配置
    public float yFixed = 0.0f;          // 通常のカメラY位置（地面）
    public float upperYThreshold = 2.5f; // プレイヤーがこの高さより上に行くとカメラも追従
    public float camYSpeed = 5.0f;       // Y方向の補間スピード
    public float zoomOut = 5.0f;         // カメラのズームアウト

    private Camera cam;
    private float currentY;              // 現在のカメラY位置

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
            // プレイヤーが上に行きすぎた場合は、カメラも追いかける
            targetY = player.transform.position.y;
        }

        // カメラYを補間してスムーズに上下移動
        currentY = Mathf.Lerp(currentY, targetY, Time.deltaTime * camYSpeed);

        // カメラ位置を更新
        Vector3 newCamPos = new Vector3(player.transform.position.x + xOffset, currentY, -10f);
        transform.position = newCamPos;
    }
}
