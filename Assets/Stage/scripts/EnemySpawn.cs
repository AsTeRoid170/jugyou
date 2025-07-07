using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // 生成するオブジェクトのPrefab
    public GameObject objectToSpawn;

    // 生成する位置
    public Transform spawnPoint;

    // トリガーに入ったオブジェクトを検知
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 特定のタグを持つオブジェクトのみ反応する場合
        if (other.CompareTag("Player"))
        {
            SpawnObject();
        }
    }

    // オブジェクトを生成する関数
    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogWarning("PrefabまたはSpawnPointが設定されていません！");
        }
    }
}
