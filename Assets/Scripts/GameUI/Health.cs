using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;      // 최대 체력
    public float timeDrainRate = 1f;    // 초당 체력 감소량
    public float fallThresholdY = -5f;  // 낙사 기준 Y 좌표

    // [HideInInspector] public float currentHealth; // 외부에서 직접 접근하지 않도록 private으로 변경
    public float CurrentHealth { get; private set; }

    // 이벤트: 체력 변경 시 (현재 체력, 최대 체력)
    public delegate void OnHealthChanged(float current, float max);
    public static event OnHealthChanged HealthChanged;

    // 이벤트: 플레이어 사망 시
    public delegate void OnPlayerDead();
    public static event OnPlayerDead PlayerDead;

    private bool isDead = false;

    private void Awake()
    {
        CurrentHealth = maxHealth; // 체력 초기화
    }

    private void Start()
    {
        // 게임 시작 시 체력 UI 즉시 업데이트
        HealthChanged?.Invoke(CurrentHealth, maxHealth);
        StartCoroutine(TimeDrain());
    }

    private IEnumerator TimeDrain()
    {
        // 플레이어가 살아있는 동안 1초마다 체력 감소
        while (CurrentHealth > 0)
        {
            yield return new WaitForSeconds(1f);
            if (!isDead) // 죽은 후에는 시간 감소 중지
            {
                TakeDamage(timeDrainRate);
            }
        }
    }

    private void Update()
    {
        // 낙사 체크
        if (!isDead && transform.position.y < fallThresholdY)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return; // 이미 죽었다면 대미지 받지 않음

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f);
        HealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // 중복 실행 방지
        isDead = true;

        PlayerDead?.Invoke();
        // 참고: 애니메이션이나 다른 효과를 위해 오브젝트 파괴를 약간 지연시킬 수 있습니다.
        // Destroy(gameObject, 2f);
        Destroy(gameObject);
    }
}

