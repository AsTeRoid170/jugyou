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

    // 各ステータスの現在値を表示するテキスト
    public Text moveSpeedValueText; 
    public Text jumpForceValueText;  
    public Text powerValueText;

    // 残り割り振りポイントを表示するテキスト
    public Text pointsRemainingText;

    // 各ステータスの最大値（0～10)
    private const int maxEachStatus = 10;

    // 割り振り可能な合計ポイントの最大値(初期値の合計)
    private int maxPoints;

    // スライダー変更前の値を保持(不正な変更を元に戻す)
    private int prevMove;

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
