using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostScore : MonoBehaviour
{
    [Header("�г� �� �ؽ�Ʈ")]
    [SerializeField] private Image panelImage;
    [SerializeField] private TextMeshProUGUI text;

    [Header("������ ����")]
    [SerializeField] private float flashSpeed = 2f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float minAlpha = 0.2f;

    [SerializeField] private Color flashTextColor = Color.yellow; // ������ �� �ؽ�Ʈ ��
    private Color originalPanelColor;
    private Color originalTextColor;

    void Start()
    {
        if (panelImage != null)
            originalPanelColor = panelImage.color;
        if (text != null)
            originalTextColor = text.color;
    }

    void Update()
    {
        if (ScoreManager.Instance != null && ScoreManager.Instance.isBestScore)
        {
            float t = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed));
            float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);

            SetPanelAlpha(alpha);
            SetTextColor(Color.Lerp(originalTextColor, flashTextColor, t));
        }
        else
        {
            SetPanelAlpha(originalPanelColor.a);
            SetTextColor(originalTextColor);
        }
    }

    private void SetPanelAlpha(float alpha)
    {
        if (panelImage == null) return;

        Color color = panelImage.color;
        color.a = alpha;
        panelImage.color = color;
    }

    private void SetTextColor(Color newColor)
    {
        if (text == null) return;
        text.color = newColor;
    }
}