using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostScore : MonoBehaviour
{
    [SerializeField] private Image panelImage; // 배경 이미지
    [SerializeField] private float maxTime = 10f; // 몇 초에 완전 불투명해질지
    private float elapsedTime = 0f;

    void Start()
    {
        // 시작 시 완전 투명하게 초기화
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
