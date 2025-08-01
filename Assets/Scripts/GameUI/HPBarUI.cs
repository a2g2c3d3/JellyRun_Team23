using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    private void OnEnable()
    {
        Health.OnHealthChanged += UpdateSlider;
    }

    private void OnDisable()
    {
        Health.OnHealthChanged -= UpdateSlider;
    }

    private void UpdateSlider(float current, float max)
    {
        if (hpSlider != null)
        {
            // �����̴��� �ִ밪, ���簪 ����
            hpSlider.maxValue = max;
            hpSlider.value = current;
        }
    }
}
