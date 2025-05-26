using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void Change_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

    public void menu_buttton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}