using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����̃^�O�����I�u�W�F�N�g�̂ݔ�������ꍇ
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
