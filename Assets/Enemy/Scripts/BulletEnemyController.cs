using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;            // íe î≠éÀà íu
    [SerializeField] GameObject bullet;                 // íe
    [SerializeField] float Interval = 5.0f;             // î≠éÀä‘äu
    GameObject player;                                  // ÉvÉåÉCÉÑÅ[ÇÃà íuÇ…ÇÊÇ¡Çƒå¸Ç´ÇïœÇ¶ÇÈ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("Shoot", 0.1f, Interval);       // àÍíËä‘äuÇ≈íeÇåÇÇ¬
        
    }

    // Update is called once per frame
    void Update()
    {
        // ÉvÉåÉCÉÑÅ[ÇÃï˚Çå¸Ç≠
        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));


            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
        }

        
    }

    // íeÇê∂ê¨Ç∑ÇÈ
    private void Shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
    }
}
