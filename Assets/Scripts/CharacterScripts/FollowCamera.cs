using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;  // 카메라와 플레이어 사이 간격
    public float smoothSpeed = 5f; // 부드럽게 따라오는 속도

    void LateUpdate()
    {
        if (target == null) return;

        // 카메라 플레이어 따라가는 기능
        Vector3 desiredPosition = new Vector3((target.position.x + offset.x), offset.y, offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
