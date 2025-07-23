using UnityEngine;

public class BigDumbbelSpawn : MonoBehaviour
{
    // ��������I�u�W�F�N�g��Prefab
    public GameObject objectToSpawn;

    // ��������ʒu
    public Transform spawnPoint;

    private float timer = 0.0f;

    // �g���K�[�ɓ������I�u�W�F�N�g�����m
    private void OnTriggerStay2D(Collider2D other)
    {
        timer += Time.deltaTime;
        // ����̃^�O�����I�u�W�F�N�g�̂ݔ�������ꍇ
        if (other.CompareTag("Player"))
        {
            if(timer>100.0f)
            {
                SpawnObject();
                timer = 0.0f;
            }
        }
    }

    // �I�u�W�F�N�g�𐶐�����֐�
    private void SpawnObject()
    {
        if (objectToSpawn != null && spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
            
        }
        else
        {
            Debug.LogWarning("Prefab�܂���SpawnPoint���ݒ肳��Ă��܂���I");
        }
    }
}
