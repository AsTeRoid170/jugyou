using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // ステータス値（初期値）
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float power = 1f;

    // UIスライダー（Canvasからアサイン）
    public Slider moveSpeedSlider;
    public Slider jumpForceSlider;
    public Slider powerSlider;

    void Start()
    {
        // 各スライダーの設定（範囲と初期値）
        if (moveSpeedSlider != null)
        {
            moveSpeedSlider.minValue = 0;
            moveSpeedSlider.maxValue = 10;
            moveSpeedSlider.value = moveSpeed;
        }

        if (jumpForceSlider != null)
        {
            jumpForceSlider.minValue = 0;
            jumpForceSlider.maxValue = 15;
            jumpForceSlider.value = jumpForce;
        }

        if (powerSlider != null)
        {
            powerSlider.minValue = 0;
            powerSlider.maxValue = 5;
            powerSlider.value = power;
        }
    }

    void Update()
    {
        // スライダーの値をリアルタイムでステータスに反映
        if (moveSpeedSlider != null) moveSpeed = moveSpeedSlider.value;
        if (jumpForceSlider != null) jumpForce = jumpForceSlider.value;
        if (powerSlider != null) power = powerSlider.value;
    }
}
