using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    // �X�e�[�^�X�l�i�����l�j
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float power = 1f;

    // UI�X���C�_�[�iCanvas����A�T�C���j
    public Slider moveSpeedSlider;
    public Slider jumpForceSlider;
    public Slider powerSlider;

    // �e�X�e�[�^�X�̌��ݒl��\������e�L�X�g
    public Text moveSpeedValueText; 
    public Text jumpForceValueText;  
    public Text powerValueText;

    // �c�芄��U��|�C���g��\������e�L�X�g
    public Text pointsRemainingText;

    // �e�X�e�[�^�X�̍ő�l�i0�`10)
    private const int maxEachStatus = 10;

    // ����U��\�ȍ��v�|�C���g�̍ő�l(�����l�̍��v)
    private int maxPoints;

    // �X���C�_�[�ύX�O�̒l��ێ�(�s���ȕύX�����ɖ߂�)
    private int prevMove;

    void Start()
    {
        // �e�X���C�_�[�̐ݒ�i�͈͂Ə����l�j
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
        // �X���C�_�[�̒l�����A���^�C���ŃX�e�[�^�X�ɔ��f
        if (moveSpeedSlider != null) moveSpeed = moveSpeedSlider.value;
        if (jumpForceSlider != null) jumpForce = jumpForceSlider.value;
        if (powerSlider != null) power = powerSlider.value;
    }
}
