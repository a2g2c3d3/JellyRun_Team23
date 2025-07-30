using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가

public class HPBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage; // Fill 이미지 연결
    [SerializeField] private Health playerHealth; // 체력 관리 스크립트 참조

    private void Start()
    {
        if (fillImage == null || playerHealth == null)
        {
            Debug.LogError("HPBarUI: 필요한 컴포넌트 레퍼런스가 없습니다.");
            enabled = false;
            return;
        }
        UpdateHealthBar(playerHealth.CurrentHealth, playerHealth.maxHealth); // 초기 체력으로 UI 설정
    }

    private void OnEnable()
    {
        // 이벤트 구독
        Health.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제 (매우 중요!)
        Health.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float current, float max)
    {
        float ratio = Mathf.Clamp01(current / max);
        fillImage.fillAmount = ratio;
    }
}
