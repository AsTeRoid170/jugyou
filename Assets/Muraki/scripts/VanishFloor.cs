using UnityEngine;

public class VanishFloor : MonoBehaviour
{
    public GameObject testObject;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            testObject.SetActive(false);
        }
    }
}
