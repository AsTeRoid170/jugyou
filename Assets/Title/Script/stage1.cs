using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stage1 : MonoBehaviour
{
    public void kettei1_button()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void return3_button()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}