using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSceneSelector : MonoBehaviour
{
    [Header("通常入力")]
    public string sceneA;
    public string sceneB;
    public string sceneStick;

    [Header("グリップ押しながら")]
    public string sceneGripA;
    public string sceneGripB;
    public string sceneGripStick;

    void Update()
    {
        bool gripHeld = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        // ===== 通常 =====
        if (!gripHeld)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
                Load(sceneA);

            if (OVRInput.GetDown(OVRInput.Button.Two))
                Load(sceneB);

            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
                Load(sceneStick);
        }
        // ===== グリップ併用 =====
        else
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
                Load(sceneGripA);

            if (OVRInput.GetDown(OVRInput.Button.Two))
                Load(sceneGripB);

            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
                Load(sceneGripStick);
        }
    }

    void Load(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
