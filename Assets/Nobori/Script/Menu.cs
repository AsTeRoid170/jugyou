using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        // �{�^�����N���b�N���ꂽ�Ƃ��Ɋ֐����Ăяo��
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        // MenuScene �ɑJ�ڂ���iScene���̓v���W�F�N�g�ɍ��킹�ĕύX�j
        SceneManager.LoadScene("MenuScene");
    }
}