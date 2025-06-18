using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeStageSelect : MonoBehaviour
{
    int stageNum;
    string stageName;
    private void Start()
    {
        stageNum = PlayerPrefs.GetInt("StageNum", 0);
        //stageNum =;
    }
    public void change_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
