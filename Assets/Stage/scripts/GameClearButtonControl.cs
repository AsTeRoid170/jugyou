using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearButtonControl : MonoBehaviour
{
    int stageNum;
    void Start()
    {
        stageNum = PlayerPrefs.GetInt("StageNum", 0);

    }

    public void change_NextStageButton()
    {
        SceneManager.LoadScene("");
    }

    public void change_RetryButton()
    {
        SceneManager.LoadScene("second");
    }

    public void change_StageSelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
