using UnityEngine;

public class goal : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�Ђ悱��������������I�Q�[���N���A�[�I");
        }
    }
}
