using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float timeDrainRate = 1f;
    [SerializeField] private float fallThresholdY = -5f;

    public float CurrentHealth { get; private set; }
    private bool isDead = false;

    public static event System.Action<float, float> OnHealthChanged; // (현재체력, 최대체력)
    public static event System.Action OnPlayerDead;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Start()
    {
        if (OnHealthChanged != null) OnHealthChanged(CurrentHealth, maxHealth);
        StartCoroutine(TimeDrain());
    }

    private IEnumerator TimeDrain()
    {
        while (CurrentHealth > 0 && !isDead)
        {
            yield return new WaitForSeconds(1f);
            TakeDamage(timeDrainRate);
        }
    }

    private void Update()
    {
        if (!isDead && transform.position.y < fallThresholdY)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return;

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f);
        if (OnHealthChanged != null) OnHealthChanged(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

   
    private void Die()
    {
        // 이미 사망한 상태라면 함수를 즉시 종료합니다.
        if (isDead) return;
        isDead = true;

        // 플레이어 사망 이벤트 호출
        if (OnPlayerDead != null)
        {
            OnPlayerDead();
        }

        // 플레이어 사망 시 게임 전체 흐름을 멈추기 위해 StageUIManager 코루틴 중지
        if (StageUIManager.Instance != null)
        {
            StageUIManager.Instance.StopAllCoroutines();
        }


        Destroy(gameObject);
        } }


