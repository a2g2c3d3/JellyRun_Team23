using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�

public class MapProgress : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float levelLength; // ���� ��ü ���� (����)

    private float lastReportedProgress = -1f;

    public static event System.Action<float> OnProgressChanged; // (���൵: 0.0 ~ 1.0)

    private void Update()
    {
        if (playerTransform == null || levelLength <= 0) return;

        float traveledDistance = playerTransform.position.x;
        float pct = Mathf.Clamp01(traveledDistance / levelLength);

        // ���൵�� ��ȭ�� ���� ���� �̺�Ʈ ȣ�� (���� ����ȭ)
        if (Mathf.Abs(pct - lastReportedProgress) > 0.001f)
        {
            lastReportedProgress = pct;
            if (OnProgressChanged != null) OnProgressChanged(pct);
        }
    }
}

    
