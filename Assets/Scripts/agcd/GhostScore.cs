using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GhostScore : MonoBehaviour
{
    [Header("ÆÐ³Î ¹× ÅØ½ºÆ®")]
    [SerializeField] private Image panelImage;
    [SerializeField] private TextMeshProUGUI text;

    [Header("±ôºýÀÓ ¼³Á¤")]
    [SerializeField] private float flashSpeed = 2f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float minAlpha = 0.2f;

    [SerializeField] private Color flashTextColor = Color.yellow; // ±ôºýÀÏ ¶§ ÅØ½ºÆ® »ö
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