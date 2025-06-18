using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectScene : MonoBehaviour
{
    public void return1_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void menureturn_buttton()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void stage1_button()
    {
        SceneManager.LoadScene("sta1seScene");
    }
    public void stage2_button()
    {
        SceneManager.LoadScene("sta2seScene");
    }
}
