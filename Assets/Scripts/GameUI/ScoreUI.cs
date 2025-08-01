using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro; // TextMeshPro 네임스페이스 추가

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        //현재 점수로 초기화
        if (ScoreManager.Instance != null)
        {
            UpdateScoreText(ScoreManager.Instance.Score);
        }
    }

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScoreText;
    }

    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"{newScore}";
        }
    }
}
