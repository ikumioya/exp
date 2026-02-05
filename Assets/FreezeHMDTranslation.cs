using UnityEngine;

public class FreezeHMDTranslation : MonoBehaviour
{
    private OVRCameraRig rig;
    private Transform trackingSpace;

    void Awake()
    {
        rig = GetComponent<OVRCameraRig>();
        if (rig == null)
            rig = FindFirstObjectByType<OVRCameraRig>();

        if (rig != null)
            trackingSpace = rig.trackingSpace;
    }

    void LateUpdate()
    {
        Freeze();
    }

    void OnBeforeRender()
    {
        Freeze();
    }

    void Freeze()
    {
        if (trackingSpace == null) return;

        Vector3 p = trackingSpace.localPosition;
        trackingSpace.localPosition = new Vector3(0f, p.y, 0f);
    }
}
