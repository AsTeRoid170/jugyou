using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseUI;  // ポーズUI（Canvasなど）

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
            Time.timeScale = 0f;         // 時間を止める
            pauseUI.SetActive(true);     // UI表示
        }
        else
        {
            Time.timeScale = 1f;         // 時間を戻す
            pauseUI.SetActive(false);    // UI非表示
        }
    }
}