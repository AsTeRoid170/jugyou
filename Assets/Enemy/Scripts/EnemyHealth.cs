using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        if (CurrentHp <= 0)
        {
            Die();
        }
    }

    // 死亡時のアニメーションを作る
    private void Die()
    {
        Destroy(gameObject);
    }
}
