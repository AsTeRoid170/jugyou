using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro���g�����߂ɕK�v

/// <summary>
/// �v���C���[�̃X�e�[�^�X���Ǘ�����N���X
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    // �X�e�[�^�X�l�i�����l�j
    public int power = 3;         // �U���́iPower�j
    public int jumpForce = 3;     // �W�����v�́iJump�j
    public int moveSpeed = 3;     // �ړ����x�iSpeed�j

    // �X���C�_�[UI�iCanvas����A�T�C���j
    public Slider powerSlider;
    public Slider jumpForceSlider;
    public Slider moveSpeedSlider;

    // �e�X�e�[�^�X�̒l��\������TextMeshPro
    public TMP_Text powerValueText;
    public TMP_Text jumpForceValueText;
    public TMP_Text moveSpeedValueText;

    // �c��|�C���g�\���pTextMeshPro
    public TMP_Text pointsRemainingText;

    // �e�X�e�[�^�X�̍ŏ��l�imin=1,0�ɂ͂Ȃ�Ȃ��j
    private const int minValue = 1;

    // �e�X�e�[�^�X�̍ő�l�i1���ڂ�����5�܂Łj
    private const int maxValue = 5;

    // ����U��\�ȍő升�v�|�C���g�i�����X�e�[�^�X�̍��v = 15�j
    private int maxPoints;

    // �O��̃X���C�_�[�l�i��r���ĕω��m�F�Ɏg���j
    private int prevPower;
    private int prevJump;
    private int prevMove;


    /// <summary>
    /// �V�[���J�n����UI�v�f���������蓖��
    /// </summary>
    private void Awake()
    {
        // GameObject����UI�I�u�W�F�N�g��T���āA�Ή�����R���|�[�l���g���擾
        powerSlider = GameObject.Find("power")?.GetComponent<Slider>();
        jumpForceSlider = GameObject.Find("jump")?.GetComponent<Slider>();
        moveSpeedSlider = GameObject.Find("speed")?.GetComponent<Slider>();

        powerValueText = GameObject.Find("P_value")?.GetComponent<TMP_Text>();
        jumpForceValueText = GameObject.Find("J_value")?.GetComponent<TMP_Text>();
        moveSpeedValueText = GameObject.Find("S_value")?.GetComponent<TMP_Text>();

        pointsRemainingText = GameObject.Find("Points_Remaining")?.GetComponent<TMP_Text>();

        // �f�o�b�O�p�Fnull�`�F�b�N
        if (powerSlider == null) Debug.LogWarning("PowerSlider ��������܂���B");
        if (jumpForceSlider == null) Debug.LogWarning("JumpSlider ��������܂���B");
        if (moveSpeedSlider == null) Debug.LogWarning("SpeedSlider ��������܂���B");
    }
    /// <summary>
    /// �����������i�X���C�_�[�ݒ�A�����X�e�[�^�X���f�j
    /// </summary>
    void Start()
    {
        // �ő�|�C���g�i�����X�e�[�^�X�̍��v�j���L�^
        maxPoints = power + jumpForce + moveSpeed;

        // �O��l��ۑ�
        prevPower = power;
        prevJump = jumpForce;
        prevMove = moveSpeed;

        // �e�X���C�_�[��ݒ�i1�`5�A�����̂݁j
        InitSlider(powerSlider, power);
        InitSlider(jumpForceSlider, jumpForce);
        InitSlider(moveSpeedSlider, moveSpeed);

        // �e�L�X�g�\���X�V
        UpdateValueTexts();
        UpdatePointsUI();
    }

    /// <summary>
    /// ���t���[���A�X���C�_�[�̏�Ԃ��`�F�b�N���A�X�e�[�^�X���X�V
    /// </summary>
    void Update()
    {
        // ���݂̃X���C�_�[�l�i�������j
        int currentPower = Mathf.RoundToInt(powerSlider.value);
        int currentJump = Mathf.RoundToInt(jumpForceSlider.value);
        int currentMove = Mathf.RoundToInt(moveSpeedSlider.value);

        // ���v�|�C���g���v�Z
        int total = currentPower + currentJump + currentMove;

        // ���v������ȓ��Ȃ�l���X�V
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
            // ���߂����X�e�[�^�X�����l��߂�
            if (currentPower != prevPower) powerSlider.value = prevPower;
            if (currentJump != prevJump) jumpForceSlider.value = prevJump;
            if (currentMove != prevMove) moveSpeedSlider.value = prevMove;
        }

        // UI�X�V
        UpdatePointsUI();
        UpdateValueTexts();
    }

    /// <summary>
    /// �e�X���C�_�[�̏����ݒ�i�ő�l�A���������Ȃǁj
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
    /// �e�X�e�[�^�X�̒l���X���C�_�[���ɕ\��
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
    /// �c��|�C���g���e�L�X�g�ɕ\���i��F�c��|�C���g: 2�j
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

    // �X�e�[�^�X�擾�p�v���p�e�B�i���X�N���v�g����Q�Ɖ\�j
    public int GetPower() => power;
    public int GetJumpForce() => jumpForce;
    public int GetMoveSpeed() => moveSpeed;
    public int GetMaxPoints() => maxPoints;
    public int GetRemainingPoints() => maxPoints - (power + jumpForce + moveSpeed);
}
