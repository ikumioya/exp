using UnityEngine;

public class MoveZLoop : MonoBehaviour
{
    public float speed = 1.0f;   // m/s
    public float distance = 6.0f; // ˆÚ“®‹——£

    private Vector3 startPos;
    private float moved = 0f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // ¡ƒtƒŒ[ƒ€‚Å“®‚­‹——£
        float step = speed * Time.deltaTime;

        // -Z•ûŒü‚ÖˆÚ“®
        transform.Translate(0, 0, -step);

        moved += step;

        // 6mi‚ñ‚¾‚ç–ß‚·
        if (moved >= distance)
        {
            transform.position = startPos;
            moved = 0f;
        }
    }
}
