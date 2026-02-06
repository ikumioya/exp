using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//移動方向のトラッキングを相殺するためのスクリプトです，トラッキングするなら剥がしてください
public class TrackingChanger : MonoBehaviour
{
    [SerializeField] Transform centerEyeTransform;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 t_pos = centerEyeTransform.position;
        this.transform.position = t_pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 t_pos = centerEyeTransform.position;
        this.transform.position = t_pos;
    }
}
