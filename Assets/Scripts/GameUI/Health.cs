using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;      // �ִ� ü��
    public float timeDrainRate = 1f;    // �ʴ� ü�� ���ҷ�
    public float fallThresholdY = -5f;  // ���� ���� Y ��ǥ

    // [HideInInspector] public float currentHealth; // �ܺο��� ���� �������� �ʵ��� private���� ����
    public float CurrentHealth { get; private set; }

    // �̺�Ʈ: ü�� ���� �� (���� ü��, �ִ� ü��)
    public delegate void OnHealthChanged(float current, float max);
    public static event OnHealthChanged HealthChanged;

    // �̺�Ʈ: �÷��̾� ��� ��
    public delegate void OnPlayerDead();
    public static event OnPlayerDead PlayerDead;

    private bool isDead = false;

    private void Awake()
    {
        CurrentHealth = maxHealth; // ü�� �ʱ�ȭ
    }

    private void Start()
    {
        // ���� ���� �� ü�� UI ��� ������Ʈ
        HealthChanged?.Invoke(CurrentHealth, maxHealth);
        StartCoroutine(TimeDrain());
    }

    private IEnumerator TimeDrain()
    {
        // �÷��̾ ����ִ� ���� 1�ʸ��� ü�� ����
        while (CurrentHealth > 0)
        {
            yield return new WaitForSeconds(1f);
            if (!isDead) // ���� �Ŀ��� �ð� ���� ����
            {
                TakeDamage(timeDrainRate);
            }
        }
    }

    private void Update()
    {
        // ���� üũ
        if (!isDead && transform.position.y < fallThresholdY)
        {
            Die();
        }
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return; // �̹� �׾��ٸ� ����� ���� ����

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f);
        HealthChanged?.Invoke(CurrentHealth, maxHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return; // �ߺ� ���� ����
        isDead = true;

        PlayerDead?.Invoke();
        // ����: �ִϸ��̼��̳� �ٸ� ȿ���� ���� ������Ʈ �ı��� �ణ ������ų �� �ֽ��ϴ�.
        // Destroy(gameObject, 2f);
        Destroy(gameObject);
    }
}

