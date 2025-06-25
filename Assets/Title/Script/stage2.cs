using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage2 : MonoBehaviour
{
    public void kettei2_button()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void return4_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}