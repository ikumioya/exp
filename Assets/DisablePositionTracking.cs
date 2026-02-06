using UnityEngine;

public class DisablePositionTracking : MonoBehaviour
{
    void Awake()
    {
        OVRManager mgr = FindFirstObjectByType<OVRManager>();

        if (mgr != null)
        {
            mgr.usePositionTracking = false;   // 歩行を無効化
            mgr.useRotationTracking = true;   // 回転は有効
        }
        else
        {
            Debug.LogWarning("OVRManager not found in scene!");
        }
    }
}
