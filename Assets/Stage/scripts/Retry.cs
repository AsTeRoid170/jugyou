using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    int stageNum;
    private void Start()
    {
        stageNum = PlayerPrefs.GetInt("StageNum", 0);

    }
    public void change_button()
    {
        SceneManager.LoadScene("second");
    }
}
