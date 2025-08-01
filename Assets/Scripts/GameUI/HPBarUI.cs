using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

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
            // 슬라이더의 최대값, 현재값 설정
            hpSlider.maxValue = max;
            hpSlider.value = current;
        }
    }
}
