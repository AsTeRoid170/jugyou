using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        // すでに存在する場合は破棄
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // このオブジェクトを次のシーンでも破棄しない
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}