using UnityEngine;
using System.Collections;

public class BulletEnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPoint;            // 弾 発射位置
    [SerializeField] GameObject bullet;                 // 弾
    [SerializeField] float Interval = 5.0f;             // 発射間隔
    GameObject player;                                  // プレイヤーの位置によって向きを変える

    Animator animator;                                  // アニメーター

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");      // プレイヤーの位置取得用
        animator = GetComponent<Animator>();            // Animator取得
        StartCoroutine(Shoot());                        // コルーチンスタート
        
    }

    // Update is called once per frame
    void Update()
    {
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

    // コルーチン 弾を撃つ
    private IEnumerator Shoot()
    {
        while (true)
        {
            animator.SetTrigger("AttackTrigger");

            // アニメーションを鑑みて一定時間ストップ
            yield return new WaitForSeconds(1.1f);

            // 弾生成
            Instantiate(bullet, bulletPoint.transform.position, Quaternion.identity);

            // Interval間隔でこの処理をする
            yield return new WaitForSeconds(Interval);
        }

        
    }
}
