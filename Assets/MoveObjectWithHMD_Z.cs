using UnityEngine;

public class MoveObjectWithHMD_Z : MonoBehaviour
{
    [Header("CenterEyeAnchor を指定")]
    [SerializeField] private Transform centerEye;

    [Header("動かしたいオブジェクト")]
    [SerializeField] private Transform targetObject;

    float lastEyeZ;

    void Start()
    {
        if (centerEye != null)
            lastEyeZ = centerEye.localPosition.z;
    }

    void LateUpdate()
    {
        if (centerEye == null || targetObject == null) return;

        float currentZ = centerEye.localPosition.z;
        float deltaZ = currentZ - lastEyeZ;

        // HMDが前後に動いた分だけ、同じ量オブジェクトをZに動かす
        targetObject.position += 0.725f *new Vector3(0f, 0f, deltaZ);

        lastEyeZ = currentZ;
    }
}
