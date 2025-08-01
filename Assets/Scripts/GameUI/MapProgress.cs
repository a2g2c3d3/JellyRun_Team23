using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class MapProgress : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float levelLength; // 맵의 전체 길이 (미터)

    private float lastReportedProgress = -1f;

    public static event System.Action<float> OnProgressChanged; // (진행도: 0.0 ~ 1.0)

    private void Update()
    {
        if (playerTransform == null || levelLength <= 0) return;

        float traveledDistance = playerTransform.position.x;
        float pct = Mathf.Clamp01(traveledDistance / levelLength);

        // 진행도에 변화가 있을 때만 이벤트 호출 (성능 최적화)
        if (Mathf.Abs(pct - lastReportedProgress) > 0.001f)
        {
            lastReportedProgress = pct;
            if (OnProgressChanged != null) OnProgressChanged(pct);
        }
    }
}

    
