using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �Q�[���X�^�[�g���������Ƃ��ɌĂ�
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
