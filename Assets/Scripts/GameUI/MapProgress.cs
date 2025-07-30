using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�

public class MapProgress : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾� Transform
    public float levelLength;         // ��ü �� ����

    private float lastReportedProgress = -1f; // ������ ����� ���൵

    // �̺�Ʈ: ���൵ ���� �� (0.0 ~ 1.0)
    public delegate void OnProgressChanged(float percentage);
    public static event OnProgressChanged ProgressChanged;

    private void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("MapProgress: �÷��̾� Transform ���۷����� �����ϴ�.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float traveledDistance = playerTransform.position.x;
        // ���൵�� 0�� 1 ���� ������ ����
        float pct = Mathf.Clamp01(traveledDistance / levelLength);

        // ���൵�� ��ȭ�� ���� ���� �̺�Ʈ�� ȣ���Ͽ� ���� ����ȭ
        if (Mathf.Abs(pct - lastReportedProgress) > 0.001f) // �̼��� ��ȭ���� �����ϵ���
        {
            lastReportedProgress = pct;
            ProgressChanged?.Invoke(pct);
        }
    }
}
