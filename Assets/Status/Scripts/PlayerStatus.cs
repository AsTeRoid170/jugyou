using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProを使うために必要

/// <summary>
/// プレイヤーのステータスを管理するクラス
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    // ステータス値（初期値）
    public int power = 3;         // 攻撃力（Power）
    public int jumpForce = 3;     // ジャンプ力（Jump）
    public int moveSpeed = 3;     // 移動速度（Speed）

    // スライダーUI（Canvasからアサイン）
    public Slider powerSlider;
    public Slider jumpForceSlider;
    public Slider moveSpeedSlider;

    // 各ステータスの値を表示するTextMeshPro
    public TMP_Text powerValueText;
    public TMP_Text jumpForceValueText;
    public TMP_Text moveSpeedValueText;

    // 残りポイント表示用TextMeshPro
    public TMP_Text pointsRemainingText;

    // 各ステータスの最小値（min=1,0にはならない）
    private const int minValue = 1;

    // 各ステータスの最大値（1項目あたり5まで）
    private const int maxValue = 5;

    // 割り振り可能な最大合計ポイント（初期ステータスの合計 = 15）
    private int maxPoints;

    // 前回のスライダー値（比較して変化確認に使う）
    private int prevPower;
    private int prevJump;
    private int prevMove;


    /// <summary>
    /// シーン開始時にUI要素を自動割り当て
    /// </summary>
    private void Awake()
    {
        // GameObject名でUIオブジェクトを探して、対応するコンポーネントを取得
        powerSlider = GameObject.Find("power")?.GetComponent<Slider>();
        jumpForceSlider = GameObject.Find("jump")?.GetComponent<Slider>();
        moveSpeedSlider = GameObject.Find("speed")?.GetComponent<Slider>();

        powerValueText = GameObject.Find("P_value")?.GetComponent<TMP_Text>();
        jumpForceValueText = GameObject.Find("J_value")?.GetComponent<TMP_Text>();
        moveSpeedValueText = GameObject.Find("S_value")?.GetComponent<TMP_Text>();

        pointsRemainingText = GameObject.Find("Points_Remaining")?.GetComponent<TMP_Text>();

        // デバッグ用：nullチェック
        if (powerSlider == null) Debug.LogWarning("PowerSlider が見つかりません。");
        if (jumpForceSlider == null) Debug.LogWarning("JumpSlider が見つかりません。");
        if (moveSpeedSlider == null) Debug.LogWarning("SpeedSlider が見つかりません。");
    }
    /// <summary>
    /// 初期化処理（スライダー設定、初期ステータス反映）
    /// </summary>
    void Start()
    {
        // 最大ポイント（初期ステータスの合計）を記録
        maxPoints = power + jumpForce + moveSpeed;

        // 前回値を保存
        prevPower = power;
        prevJump = jumpForce;
        prevMove = moveSpeed;

        // 各スライダーを設定（1～5、整数のみ）
        InitSlider(powerSlider, power);
        InitSlider(jumpForceSlider, jumpForce);
        InitSlider(moveSpeedSlider, moveSpeed);

        // テキスト表示更新
        UpdateValueTexts();
        UpdatePointsUI();
    }

    /// <summary>
    /// 毎フレーム、スライダーの状態をチェックし、ステータスを更新
    /// </summary>
    void Update()
    {
        // 現在のスライダー値（整数化）
        int currentPower = Mathf.RoundToInt(powerSlider.value);
        int currentJump = Mathf.RoundToInt(jumpForceSlider.value);
        int currentMove = Mathf.RoundToInt(moveSpeedSlider.value);

        // 合計ポイントを計算
        int total = currentPower + currentJump + currentMove;

        // 合計が上限以内なら値を更新
        if (total <= maxPoints)
        {
            power = currentPower;
            jumpForce = currentJump;
            moveSpeed = currentMove;

            prevPower = power;
            prevJump = jumpForce;
            prevMove = moveSpeed;
        }
        else
        {
            // 超過したステータスだけ値を戻す
            if (currentPower != prevPower) powerSlider.value = prevPower;
            if (currentJump != prevJump) jumpForceSlider.value = prevJump;
            if (currentMove != prevMove) moveSpeedSlider.value = prevMove;
        }

        // UI更新
        UpdatePointsUI();
        UpdateValueTexts();
    }

    /// <summary>
    /// 各スライダーの初期設定（最大値、整数制限など）
    /// </summary>
    void InitSlider(Slider slider, int initialValue)
    {
        if (slider != null)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.wholeNumbers = true;
            slider.value = initialValue;
        }
    }

    /// <summary>
    /// 各ステータスの値をスライダー横に表示
    /// </summary>
    void UpdateValueTexts()
    {
        if (powerValueText != null)
            powerValueText.text = power.ToString();

        if (jumpForceValueText != null)
            jumpForceValueText.text = jumpForce.ToString();

        if (moveSpeedValueText != null)
            moveSpeedValueText.text = moveSpeed.ToString();
    }

    /// <summary>
    /// 残りポイントをテキストに表示（例：残りポイント: 2）
    /// </summary>
    void UpdatePointsUI()
    {
        int used = power + jumpForce + moveSpeed;
        int remaining = maxPoints - used;

        if (pointsRemainingText != null)
        {
            pointsRemainingText.text = "Point: " + remaining;
        }
    }

    // ステータス取得用プロパティ（他スクリプトから参照可能）
    public int GetPower() => power;
    public int GetJumpForce() => jumpForce;
    public int GetMoveSpeed() => moveSpeed;
    public int GetMaxPoints() => maxPoints;
    public int GetRemainingPoints() => maxPoints - (power + jumpForce + moveSpeed);
}
