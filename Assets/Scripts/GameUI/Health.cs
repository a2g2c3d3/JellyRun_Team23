using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class Health : MonoBehaviour
{
    [Header("ü�� ����")]
    [SerializeField] private float maxHealth = 120f;
    [SerializeField] private float timeDrainRate = 1f;
    [SerializeField] private float fallThresholdY = -5f;

    [Header("�÷��̾� �ݶ��̴�")]
    [SerializeField] private Collider2D playerCollider;

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


        ScoreManager.Instance.SaveBestScore();
        OnPlayerDead?.Invoke();
        // ���� ���� �̺�Ʈ ȣ�� (���â�� ���� ����)
        StageUIManager.OnGameFinished?.Invoke();


        // �÷��̾� ��� �� ���� ��ü �帧�� ���߱� ���� StageUIManager �ڷ�ƾ ����
        if (StageUIManager.Instance != null)
        {
            StageUIManager.Instance.StopAllCoroutines();
        }

        // Health ��ũ��Ʈ�� �ڷ�ƾ�� ��������� �����մϴ�.
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

    public void PlusHP(float amount) //ü������ �Լ� �߰� 
    {
        if (CurrentHealth < maxHealth) //�ƽ����� �������� ü�� �߰�
        {
            CurrentHealth += Mathf.Max(CurrentHealth - amount, 0f);

            if (CurrentHealth > maxHealth) //�߰� �� �ƽ�ü�� �Ѿ��� ��� ����ȭ
            {
                CurrentHealth = maxHealth;
            }
        }
    }
}


