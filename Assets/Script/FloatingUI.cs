using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    public float moveY = 10f;      // tinggi naik turun
    public float speed = 2f;       // kecepatan
    public float moveX = 5f;       // goyangan kiri kanan

    Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * speed) * moveY;
        float offsetX = Mathf.Cos(Time.time * speed * 0.8f) * moveX;

        transform.localPosition = startPos + new Vector3(offsetX, offsetY, 0);
    }
}