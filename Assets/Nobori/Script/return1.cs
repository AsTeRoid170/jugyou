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
}
