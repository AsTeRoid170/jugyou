using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // ���j���[���������Ƃ��ɌĂ�
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // �Q�[���X�^�[�g���������Ƃ��ɌĂ�
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
