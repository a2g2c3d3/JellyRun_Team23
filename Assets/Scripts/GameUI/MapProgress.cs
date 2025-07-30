using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class MapProgress : MonoBehaviour
{
    public Transform playerTransform; // 플레이어 Transform
    public float levelLength;         // 전체 맵 길이

    private float lastReportedProgress = -1f; // 이전에 보고된 진행도

    // 이벤트: 진행도 변경 시 (0.0 ~ 1.0)
    public delegate void OnProgressChanged(float percentage);
    public static event OnProgressChanged ProgressChanged;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("MapProgress: 플레이어 Transform 레퍼런스가 없습니다.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float traveledDistance = playerTransform.position.x;
        // 진행도를 0과 1 사이 값으로 제한
        float pct = Mathf.Clamp01(traveledDistance / levelLength);

        // 진행도에 변화가 있을 때만 이벤트를 호출하여 성능 최적화
        if (Mathf.Abs(pct - lastReportedProgress) > 0.001f) // 미세한 변화에도 반응하도록
        {
            lastReportedProgress = pct;
            ProgressChanged?.Invoke(pct);
        }
    }
}
