using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro; // TextMeshPro 네임스페이스 추가

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수 표시 텍스트

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreUI: 텍스트 레퍼런스가 없습니다.");
            enabled = false;
            return;
        }
        // 시작할 때 현재 점수로 UI 초기화
        UpdateScoreText(ScoreManager.Instance.Score);
    }

    private void OnEnable()
    {
        ScoreManager.ScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.ScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"{newScore}";
        }
    }
}
