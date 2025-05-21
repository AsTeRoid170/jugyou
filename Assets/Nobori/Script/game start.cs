using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // ゲームスタートを押したときに呼ぶ
    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
