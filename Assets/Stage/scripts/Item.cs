using UnityEngine;

public class Item : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth health= collision.gameObject.GetComponent<PlayerHealth>();
            health.TakeHeal();
            Destroy(this.gameObject);
        }
    }
}
