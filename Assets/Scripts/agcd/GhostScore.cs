using UnityEngine;
using UnityEngine.UI;

public class GhostScore : MonoBehaviour
{
    [SerializeField] private Image panelImage;        // ������ �̹���
    [SerializeField] private float flashSpeed = 10f;   // ������ �ӵ� (Ŀ������ ����)
    [SerializeField] private float maxAlpha = 1f;     // ���� ���� �� ����
    [SerializeField] private float minAlpha = 0.2f;   // ���� ��ο� �� ����

    private Color originalColor;

    void Start()
    {
        if (panelImage != null)
            originalColor = panelImage.color; // ���� �� ����
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
            SetAlpha(originalColor.a); // ��ҿ� ���� ���İ� ����
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


