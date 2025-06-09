using UnityEngine;

public class BossPunch : MonoBehaviour
{
    [SerializeField] int damage = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            player.TakeDamage(damage);
        }
    }
}
