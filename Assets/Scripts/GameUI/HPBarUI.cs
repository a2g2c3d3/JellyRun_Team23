using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage; // Fill �̹��� ����
    [SerializeField] private Health playerHealth; // ü�� ���� ��ũ��Ʈ ����

    private void Start()
    {
        if (fillImage == null || playerHealth == null)
        {
            Debug.LogError("HPBarUI: �ʿ��� ������Ʈ ���۷����� �����ϴ�.");
            enabled = false;
            return;
        }
        UpdateHealthBar(playerHealth.CurrentHealth, playerHealth.maxHealth); // �ʱ� ü������ UI ����
    }

    private void OnEnable()
    {
        // �̺�Ʈ ����
        Health.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        // �̺�Ʈ ���� ���� (�ſ� �߿�!)
        Health.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float current, float max)
    {
        float ratio = Mathf.Clamp01(current / max);
        fillImage.fillAmount = ratio;
    }
}
