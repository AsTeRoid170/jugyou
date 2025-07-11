using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour

{
    [SerializeField] int MaxHp = 15;
    int CurrentHp;

    [SerializeField] Slider hpSlider;
    [SerializeField] Image fillImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHp = MaxHp;
        hpSlider.maxValue = MaxHp;
        hpSlider.value = CurrentHp;
        UpdateHPUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("攻撃受けてる");
        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Debug.Log("死んでます");
            Die();
        }
        UpdateHPUI();
    }

    void UpdateHPUI()
    {
        hpSlider.value = CurrentHp;

        float hpRatio = (float)CurrentHp / MaxHp;

        if (hpRatio > 0.5f)
        {
            fillImage.color = Color.green; // HP高い
        }
        else if (hpRatio > 0.25f)
        {
            fillImage.color = Color.yellow; // HP中
        }
        else
        {
            fillImage.color = Color.red; // HP低い
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}

