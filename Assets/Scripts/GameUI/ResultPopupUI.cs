using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class ResultPopupUI : MonoBehaviour
{
    [Header("UI ���")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ

    private bool isResultShown = false;

    private void Start()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
    }

    private void OnEnable()
    {
        // ���� ���� �̺�Ʈ ���� (�÷��̾� ��� �Ǵ� �ð� ����)
        StageUIManager.OnGameFinished += ShowResult;
    }

    private void OnDisable()
    {
        StageUIManager.OnGameFinished -= ShowResult;
    }

    private void ShowResult()
    {
        if (isResultShown) return;
        isResultShown = true;

        Time.timeScale = 0f;

        if (popupPanel != null) popupPanel.SetActive(true);

        // ���� ���� ǥ��
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.Score}";
        }

        // ���� �ð� ǥ��
        if (timeText != null && StageUIManager.Instance != null)
        {
            // 1. totalTimeRemaining ��� TotalTimeRemaining ������Ƽ�� ����մϴ�.
            float t = StageUIManager.Instance.TotalTimeRemaining;
            int minutes = Mathf.FloorToInt(t / 60f);
            int seconds = Mathf.FloorToInt(t % 60f);
            timeText.text = $"Time Left: {minutes:00}:{seconds:00}";
        }
    }
}
