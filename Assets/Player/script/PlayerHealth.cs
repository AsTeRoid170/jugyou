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
        Debug.Log("UŒ‚ó‚¯‚Ä‚é");
        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Debug.Log("€‚ñ‚Å‚Ü‚·");
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}

