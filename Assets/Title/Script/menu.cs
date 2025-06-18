using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void return2_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void select1_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }

}
