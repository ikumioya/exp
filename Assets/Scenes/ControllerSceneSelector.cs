using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSceneSelectorRaw : MonoBehaviour
{
    [Header("通常入力")]
    public string sceneA, sceneB, sceneStickClick;

    [Header("右グリップ押しながら")]
    public string sceneGripA, sceneGripB, sceneGripStickClick;

    [Header("グリップしきい値")]
    public float gripThreshold = 0.6f;

    void Update()
    {
        // 右グリップ（アナログ）
        float grip = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        bool gripHeld = grip > gripThreshold;

        // A/B（右）
        bool aDown = OVRInput.GetDown(OVRInput.RawButton.A);
        bool bDown = OVRInput.GetDown(OVRInput.RawButton.B);

        // 右スティック押し込み（クリック）
        bool stickClickDown = OVRInput.GetDown(OVRInput.RawButton.RThumbstick);

        if (!gripHeld)
        {
            if (aDown) Load(sceneA);
            else if (bDown) Load(sceneB);
            else if (stickClickDown) Load(sceneStickClick);
        }
        else
        {
            if (aDown) Load(sceneGripA);
            else if (bDown) Load(sceneGripB);
            else if (stickClickDown) Load(sceneGripStickClick);
        }
    }

    void Load(string name)
    {
        if (!string.IsNullOrEmpty(name))
            SceneManager.LoadScene(name);
    }
}
