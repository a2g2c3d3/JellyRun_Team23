using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro; // TextMeshPro 네임스페이스 추가

public class ResultPopupUI : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText; // 남은 시간을 표시할 텍스트

    private bool isResultShown = false;

    private void Start()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
    }

    private void OnEnable()
    {
        // 게임 종료 이벤트 구독 (플레이어 사망 또는 시간 종료)
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

        // 최종 점수 표시
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.Score}";
        }

        // 남은 시간 표시
        if (timeText != null && StageUIManager.Instance != null)
        {
            // 1. totalTimeRemaining 대신 TotalTimeRemaining 프로퍼티를 사용합니다.
            float t = StageUIManager.Instance.TotalTimeRemaining;
            int minutes = Mathf.FloorToInt(t / 60f);
            int seconds = Mathf.FloorToInt(t % 60f);
            timeText.text = $"Time Left: {minutes:00}:{seconds:00}";
        }
    }
}
