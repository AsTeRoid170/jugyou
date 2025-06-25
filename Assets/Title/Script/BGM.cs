using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        // ���łɑ��݂���ꍇ�͔j��
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // ���̃I�u�W�F�N�g�����̃V�[���ł��j�����Ȃ�
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}