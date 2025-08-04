using Player;
using UnityEngine;
using UnityEngine.UI;

public class BoostHP : MonoBehaviour
{
    [SerializeField] private Image panelImage;        // ������ �̹���
    [SerializeField] private float flashSpeed = 10f;   // ������ �ӵ�
    [SerializeField] private Color flashColor = new Color(1f, 0.84f, 0f, 1f); // �ݻ� RGBA
    public PlayerMovement player;

    private Color originalColor;

    void Start()
    {
        if (panelImage != null)
            originalColor = panelImage.color; // ���� �� ����
    }

    void Update()
    {
        if (panelImage == null || player == null) return;

        if (player.speed == 25)
        {
            float t = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed));
            Color lerped = Color.Lerp(originalColor, flashColor, t);
            panelImage.color = lerped;
        }
        else
        {
            panelImage.color = originalColor; // ���� �� ����
        }
    }
}