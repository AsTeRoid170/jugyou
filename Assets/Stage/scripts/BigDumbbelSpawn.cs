using UnityEngine;

public class BigDumbbelSpawn : MonoBehaviour
{
    // ��������I�u�W�F�N�g��Prefab
    public GameObject objectToSpawn;

    // ��������ʒu
    public Transform spawnPoint;

    // �g���K�[�ɓ������I�u�W�F�N�g�����m
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ����̃^�O�����I�u�W�F�N�g�̂ݔ�������ꍇ
        if (other.CompareTag("Player"))
        {
            SpawnObject();
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
