using UnityEngine;
using UnityEngine.UI;

public class GhostScore : MonoBehaviour
{
    [SerializeField] private Image panelImage;        // 깜빡일 이미지
    [SerializeField] private float flashSpeed = 10f;   // 깜빡임 속도 (커질수록 빠름)
    [SerializeField] private float maxAlpha = 1f;     // 가장 밝을 때 투명도
    [SerializeField] private float minAlpha = 0.2f;   // 가장 어두울 때 투명도

    private Color originalColor;

    void Start()
    {
        if (panelImage != null)
            originalColor = panelImage.color; // 원래 색 저장
    }

    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.isBestScore)
        {
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.Abs(Mathf.Sin(Time.time * flashSpeed)));
            SetAlpha(alpha);
        }
        else
        {
            SetAlpha(originalColor.a); // 평소엔 원래 알파값 유지
        }
    }

    private void SetAlpha(float alpha)
    {
        if (panelImage == null) return;

        Color color = panelImage.color;
        color.a = alpha;
        panelImage.color = color;
    }
}


