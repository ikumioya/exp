using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToHub : MonoBehaviour
{
    [Header("親シーン名")]
    public string parentSceneName;

    void Update()
    {
        // Quest 右コントローラ A ボタン
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            SceneManager.LoadScene(parentSceneName);
        }
    }
}
