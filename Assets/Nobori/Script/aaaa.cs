using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // メニューを押したときに呼ぶ
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // ゲームスタートを押したときに呼ぶ
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
