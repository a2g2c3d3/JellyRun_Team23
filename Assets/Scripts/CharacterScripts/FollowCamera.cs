using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;  // ī�޶�� �÷��̾� ���� ����
    public float smoothSpeed = 5f; // �ε巴�� ������� �ӵ�

    void LateUpdate()
    {
        if (target == null) return;

        // ī�޶� �÷��̾� ���󰡴� ���
        Vector3 desiredPosition = new Vector3((target.position.x + offset.x), offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
