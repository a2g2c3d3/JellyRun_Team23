using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private Transform center; // �߽���
    [SerializeField] private float speed = 50f; // ȸ�� �ӵ�

    void Update()
    {
        if (center != null)
        {
            // �߽��� �������� Z�� ȸ�� (2D ����)
            transform.RotateAround(center.position, Vector3.forward, speed * Time.deltaTime);
        }
    }
}