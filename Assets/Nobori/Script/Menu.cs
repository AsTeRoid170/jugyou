using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        // ボタンがクリックされたときに関数を呼び出す
        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        // MenuScene に遷移する（Scene名はプロジェクトに合わせて変更）
        SceneManager.LoadScene("MenuScene");
    }
}