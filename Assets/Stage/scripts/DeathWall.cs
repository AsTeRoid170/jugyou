using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    private float MoveSpeed = 3.0f;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 特定のタグを持つオブジェクトのみ反応する場合
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void SpeedUp()
    {
        MoveSpeed++;
    } 
}
