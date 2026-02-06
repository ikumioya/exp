using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerSceneSelectorRaw : MonoBehaviour
{
    [Header("通常入力")]
    public string sceneA, sceneB, sceneStick;

    [Header("右グリップ押しながら")]
    public string sceneGripA, sceneGripB, sceneGripStick;

    [Header("スティック倒し判定")]
    public float stickThreshold = 0.7f; // 0.5〜0.8で調整

    bool prevStickActive;

    void Update()
    {
        // 右グリップ（アナログ）
        float grip = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger);
        bool gripHeld = grip > 0.6f;

        // A/B
        bool aDown = OVRInput.GetDown(OVRInput.RawButton.A);
        bool bDown = OVRInput.GetDown(OVRInput.RawButton.B);

        // 右スティック倒し
        Vector2 stick = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        bool stickActive = stick.magnitude > stickThreshold;

        // 押した瞬間だけ反応させる
        bool stickDown = stickActive && !prevStickActive;
        prevStickActive = stickActive;

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
