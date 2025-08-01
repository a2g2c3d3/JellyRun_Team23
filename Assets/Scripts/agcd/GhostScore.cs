using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostScore : MonoBehaviour
{
    [SerializeField] private Image panelImage; // ��� �̹���
    [SerializeField] private float maxTime = 10f; // �� �ʿ� ���� ������������
    private float elapsedTime = 0f;

    void Start()
    {
        // ���� �� ���� �����ϰ� �ʱ�ȭ
        Color color = panelImage.color;
        color.a = 0f;
        panelImage.color = color;
    }

    void Update()
    {
        if (elapsedTime < maxTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / maxTime); // 0~1
            Color color = panelImage.color;
            color.a = alpha;
            panelImage.color = color;
        }
    }
}
