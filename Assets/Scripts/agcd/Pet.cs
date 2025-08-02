using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private Transform center; // 중심점
    [SerializeField] private float speed = 50f; // 회전 속도

    void Update()
    {
        if (center != null)
        {
            // 중심을 기준으로 Z축 회전 (2D 기준)
            transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}