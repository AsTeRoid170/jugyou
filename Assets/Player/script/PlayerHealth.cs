using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Debug.Log("�U���󂯂Ă�");
        CurrentHp -= amount;
        if (CurrentHp <= 0)
        {
            Debug.Log("����ł܂�");
            Die();
        }
        UpdateHPUI();
    }
    public void TakeHeal()
    {
        CurrentHp = MaxHp;

        UpdateHPUI();
    }

    void UpdateHPUI()
    {
        hpSlider.value = CurrentHp;

        float hpRatio = (float)CurrentHp / MaxHp;

        if (hpRatio > 0.5f)
        {
            fillImage.color = Color.green; // HP����
        }
        else if (hpRatio > 0.25f)
        {
            fillImage.color = Color.yellow; // HP��
        }
        else
        {
            fillImage.color = Color.red; // HP�Ⴂ
        }
    }

    private void Die()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("PlayStageNum", sceneNum);
        SceneManager.LoadScene("GameOverScene");
        Destroy(gameObject);
    }

}

