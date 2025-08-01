using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("ü�� ����")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float timeDrainRate = 1f;
    [SerializeField] private float fallThresholdY = -5f;

    public float CurrentHealth { get; private set; }
    private bool isDead = false;

    public static event System.Action<float, float> OnHealthChanged; // (����ü��, �ִ�ü��)
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
        // �̹� ����� ���¶�� �Լ��� ��� �����մϴ�.
        if (isDead) return;
        isDead = true;

        // �÷��̾� ��� �̺�Ʈ ȣ��
        if (OnPlayerDead != null)
        {
            OnPlayerDead();
        }

        // �÷��̾� ��� �� ���� ��ü �帧�� ���߱� ���� StageUIManager �ڷ�ƾ ����
        if (StageUIManager.Instance != null)
        {
            StageUIManager.Instance.StopAllCoroutines();
        }


        Destroy(gameObject);
        } }


