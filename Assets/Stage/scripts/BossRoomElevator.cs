using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRoomElevator : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("BossStage");
        }
    }
}
