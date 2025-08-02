using UnityEngine;

public class CameraColor : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float speed = 1f;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float r = Mathf.Sin(Time.time * speed) * 0.5f + 0.5f;
        float g = Mathf.Sin(Time.time * speed + 2f) * 0.5f + 0.5f;
        float b = Mathf.Sin(Time.time * speed + 4f) * 0.5f + 0.5f;

        cam.backgroundColor = new Color(r, g, b);
    }
}