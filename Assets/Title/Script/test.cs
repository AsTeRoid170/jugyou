using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseUI;  // �|�[�YUI�iCanvas�Ȃǁj

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;         // ���Ԃ��~�߂�
            pauseUI.SetActive(true);     // UI�\��
        }
        else
        {
            Time.timeScale = 1f;         // ���Ԃ�߂�
            pauseUI.SetActive(false);    // UI��\��
        }
    }
}