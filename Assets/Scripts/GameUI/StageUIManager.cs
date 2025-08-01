using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

/// <summary>
/// �������� UI ��ü�� �����ϴ� Ŭ����
/// - Ÿ�̸�, ����/Ŭ���� �ؽ�Ʈ, ���â, �˾� UI ����
/// - ������ �÷��� �� �ܺο��� �߰��� (��: ���� ȹ��)
/// </summary>
public class StageUIManager : MonoBehaviour
{
    public static StageUIManager Instance { get; private set; }

    [Header("�������� ����")]
    [SerializeField] private float[] stageDurations = { 30f, 30f, 30f, 30f }; // ���������� �ð�(��). Inspector���� ������ �ð� ���� ����
    [Header("���� ����")]
    [SerializeField] private int currentStage;
    [SerializeField] private float totalTimeRemaining;


    public int CurrentStage => currentStage;
    public float TotalTimeRemaining => totalTimeRemaining;

    // --- �̺�Ʈ ���� ---
    public static event System.Action<int> OnStageStart;
    public static event System.Action OnGameClear;
    public static event System.Action<float> OnTotalProgressUpdate;

    public static Action OnGameFinished;

    private float totalGameTime; // ���� ��ü �ð��� ������ ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // �� ���� �ð��� �̸� ���
        totalGameTime = 0;
        foreach (float duration in stageDurations)
        {
            totalGameTime += duration;
        }
    }

     public void ShowResultPanel()
    {
        // ���â�� ���� ��� ����
    }

    private void Start()
    {
        OnGameFinished += ShowResultPanel;
        // ���� ���� �� �ð� �ʱ�ȭ �� �������� ���� �ڷ�ƾ ����
        totalTimeRemaining = totalGameTime;
        StartCoroutine(RunGameStages());
    }

    private IEnumerator RunGameStages()
    {
        // �迭�� ���̸� �� �������� ���� ���
        for (int i = 0; i < stageDurations.Length; i++)
        {
            // 1. private ���� currentStage�� ���� �Ҵ�
            currentStage = i + 1; // �������� ��ȣ�� 1���� ����

            // �������� ���� �̺�Ʈ ȣ��
            if (OnStageStart != null)
            {
                // 2. �̺�Ʈ ȣ�� �ÿ��� private ���� currentStage ���
                OnStageStart(currentStage);
            }

            // ���� ���������� �´� �ð��� �迭���� ������
            float stageTimer = stageDurations[i];
            while (stageTimer > 0)
            {
                // Time.timeScale�� ������ �޵��� Time.deltaTime ���
                stageTimer -= Time.deltaTime;
                totalTimeRemaining -= Time.deltaTime;

                // ��ü ���൵(1.0 -> 0.0)�� ����Ͽ� �̺�Ʈ ȣ��
                float progress = Mathf.Clamp01(totalTimeRemaining / totalGameTime);
                if (OnTotalProgressUpdate != null)
                {
                    OnTotalProgressUpdate(progress);
                }

                yield return null; // ���� �����ӱ��� ���
            }
        }

        // --- ��� �������� �Ϸ� ---
        // ���� Ŭ���� �̺�Ʈ ȣ��
        if (OnGameClear != null)
        {
            OnGameClear();
        }

        // Ŭ���� �ؽ�Ʈ�� �����ֱ� ���� 2�� ���
        yield return new WaitForSeconds(2f);

        // ���� ���� ���� �̺�Ʈ ȣ�� (���â ǥ�� Ʈ����)
        if (OnGameFinished != null)
        {
            OnGameFinished();
        }
    }
}

