using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 特定のタグを持つオブジェクトのみ反応する場合
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
