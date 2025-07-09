using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage3 : MonoBehaviour
{
    public void kettei3_button()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void return5_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}