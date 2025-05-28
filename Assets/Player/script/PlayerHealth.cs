using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        Debug.Log("�U���󂯂Ă�");
        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Debug.Log("����ł܂�");
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

