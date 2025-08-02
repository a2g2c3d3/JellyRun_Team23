using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class Health : MonoBehaviour
{
    [Header("체력 설정")]
    [SerializeField] private float maxHealth = 120f;
    [SerializeField] private float timeDrainRate = 1f;
    [SerializeField] private float fallThresholdY = -5f;

    [Header("플레이어 콜라이더")]
    [SerializeField] private Collider2D playerCollider;

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


        ScoreManager.Instance.SaveBestScore();
        OnPlayerDead?.Invoke();
        // 게임 종료 이벤트 호출 (결과창을 띄우는 역할)
        StageUIManager.OnGameFinished?.Invoke();


        // 플레이어 사망 시 게임 전체 흐름을 멈추기 위해 StageUIManager 코루틴 중지
        if (StageUIManager.Instance != null)
        {
            StageUIManager.Instance.StopAllCoroutines();
        }

        // Health 스크립트의 코루틴도 명시적으로 중지합니다.
        StopAllCoroutines();

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        if (playerCollider != null)
        {
            playerCollider.enabled = false;
        }

    }

    public void PlusHP(float amount) //체력증가 함수 추가 
    {
        if (CurrentHealth < maxHealth) //맥스보다 낮을때만 체력 추가
        {
            CurrentHealth += Mathf.Max(CurrentHealth - amount, 0f);

            if (CurrentHealth > maxHealth) //추가 후 맥스체력 넘었을 경우 정상화
            {
                CurrentHealth = maxHealth;
            }
        }
    }
}


