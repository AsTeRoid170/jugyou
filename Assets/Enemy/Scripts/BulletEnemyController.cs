using UnityEngine;
using System.Collections;

public class BulletEnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;            // 弾 発射位置
    [SerializeField] GameObject bullet;                 // 弾
    [SerializeField] float Interval = 5.0f;             // 発射間隔
    GameObject player;                                  // プレイヤーの位置によって向きを変える

    Animator animator;                                  // アニメーター
    float animatorCount = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        StartCoroutine(Shoot());
        //InvokeRepeating("Shoot",0, Interval);       // 一定間隔で弾を撃つ
        
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーター処理
        //animatorCount += Time.deltaTime;
        //if (animatorCount > Interval - 0.35)
        //{
           // animator.SetTrigger("AttackTrigger");
            //animatorCount = 0;
        //}

        // プレイヤーの方を向く
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

    // 弾を生成する
    /*private void Shoot()
    {
        animator.SetTrigger("AttackTrigger");
        Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);
    }*/

    // コルーチン
    private IEnumerator Shoot()
    {
        while (true)
        {
            animator.SetTrigger("AttackTrigger");

            // 3秒間待つ
            yield return new WaitForSeconds(1.1f);

            // 3秒後に原点にワープ
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(Interval);
        }

        
    }
}
