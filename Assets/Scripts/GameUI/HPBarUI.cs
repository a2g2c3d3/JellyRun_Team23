using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

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

    // 슬라이더 업데이트 대신 이미지 채우기 업데이트
    private void UpdateHPImage(float current, float max)
    {
        if (hpImage != null)
        {
            // 체력 비율을 계산하여 이미지의 fillAmount 속성을 조절합니다.
            hpImage.fillAmount = current / max;
        }
    }
}
