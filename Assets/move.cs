using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class move : MonoBehaviour
{
    public Transform player;   // プレイヤー（MainCamera）
    public float speed = 1f;   // 移動速度 (m/s)

    public float rightDistance = 15f; // 右側開始位置
    public float leftDistance = -15f; // 左側終了位置

    private float startX;
    private float endX;

    void Start()
    {
        // プレイヤー基準で初期位置設定
        startX = player.position.x + rightDistance;
        endX = player.position.x + leftDistance;

        Vector3 pos = transform.position;
        pos.x = startX;
        transform.position = pos;
    }

    void Update()
    {
        // 左方向へ 1m/s 移動
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

        // 左端に到達したら右側へワープ
        if (transform.position.x <= endX)
        {
            // プレイヤーの現在位置基準で再設定
            startX = player.position.x + rightDistance;
            endX = player.position.x + leftDistance;

            Vector3 pos = transform.position;
            pos.x = startX;
            transform.position = pos;
        }
    }
}

