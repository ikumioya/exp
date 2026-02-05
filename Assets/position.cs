using UnityEngine;

public class position : MonoBehaviour
{
    private OVRCameraRig rig;
    private Transform trackingSpace;

    void Awake()
    {
        rig = GetComponent<OVRCameraRig>();
        if (rig == null)
        {
            rig = FindFirstObjectByType<OVRCameraRig>();
        }

        if (rig != null)
        {
            trackingSpace = rig.trackingSpace;
        }
    }

    void LateUpdate()
    {
        if (trackingSpace == null) return;

        Vector3 p = trackingSpace.localPosition;

        // XZを完全固定（歩いても進まない）
        trackingSpace.localPosition = new Vector3(0f, p.y, 0f);
    }
}