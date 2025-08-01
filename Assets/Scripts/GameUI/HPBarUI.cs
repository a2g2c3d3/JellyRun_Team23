using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Image hpImage;

    private void OnEnable()
    {
        Health.OnHealthChanged += UpdateHPImage;
    }

    private void OnDisable()
    {
        Health.OnHealthChanged -= UpdateHPImage;
    }

    // �����̴� ������Ʈ ��� �̹��� ä��� ������Ʈ
    private void UpdateHPImage(float current, float max)
    {
        if (hpImage != null)
        {
            // ü�� ������ ����Ͽ� �̹����� fillAmount �Ӽ��� �����մϴ�.
            hpImage.fillAmount = current / max;
        }
    }
}
