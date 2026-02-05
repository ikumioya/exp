using UnityEngine;

public class FreezeCenterEyeXZ : MonoBehaviour
{
    [SerializeField] private Transform centerEye;

    void LateUpdate() => Freeze();
    void OnBeforeRender() => Freeze();

    void Freeze()
    {
        if (centerEye == null) return;
        Vector3 p = centerEye.localPosition;
        centerEye.localPosition = new Vector3(0f, p.y, 0f);
    }
}
