using UnityEngine;

public class BulletEnemyAttack : MonoBehaviour
{
    [SerializeField ]GameObject bulletPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float Interval = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 0f, Interval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
    }
}
