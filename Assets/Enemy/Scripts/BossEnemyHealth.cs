using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHp = 15;
    int CurrentHp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;
        Debug.Log(CurrentHp);
        Debug.Log(amount);
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    // ���S���̃A�j���[�V���������
    private void Die()
    {
        SceneManager.LoadScene("BossGameClearScene");
        Destroy(gameObject);
    }
}
