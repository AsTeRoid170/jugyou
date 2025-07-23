using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    int sceneNum;
    private void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log(sceneNum);
            PlayerPrefs.SetInt("PlayStageNum",sceneNum);
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
