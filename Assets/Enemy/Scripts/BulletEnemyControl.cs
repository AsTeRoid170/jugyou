using UnityEngine;

public class BulletEnemyControl : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float Interval = 5.0f;
    [SerializeField] GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Shoot", 0f, Interval);

    }

    // Update is called once per frame
    void Update()
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

    private void Shoot()
    {
        Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
    }
}
