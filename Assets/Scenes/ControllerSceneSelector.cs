using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSceneSelectorRaw : MonoBehaviour
{
    [Header("通常入力")]
    public string sceneA, sceneB, sceneStick;
    [Header("右グリップ押しながら")]
    public string sceneGripA, sceneGripB, sceneGripStick;

    void Update()
    {
        // 右グリップ（アナログ）: RawAxisで確実に取る
        float grip = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        bool gripHeld = grip > 0.6f;

        // A/B（右手）
        bool aDown = OVRInput.GetDown(OVRInput.RawButton.A);
        bool bDown = OVRInput.GetDown(OVRInput.RawButton.B);

        // 右スティック押し込み
        bool stickDown = OVRInput.GetDown(OVRInput.RawButton.RThumbstick);

        if (!gripHeld)
        {
            if (aDown) Load(sceneA);
            else if (bDown) Load(sceneB);
            else if (stickDown) Load(sceneStick);
        }
        else
        {
            if (aDown) Load(sceneGripA);
            else if (bDown) Load(sceneGripB);
            else if (stickDown) Load(sceneGripStick);
        }
    }

    void Load(string name)
    {
        if (!string.IsNullOrEmpty(name))
            SceneManager.LoadScene(name);
    }
}