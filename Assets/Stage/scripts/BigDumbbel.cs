using UnityEngine;
using UnityEngine.SceneManagement;

public class BigDumbbel : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    [SerializeField] int AttackPower = 30;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime*-1, 4, 0);
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(AttackPower);
            Destroy(this.gameObject);
        }

        
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(AttackPower);
            Destroy(this.gameObject);
        }
    }

}
