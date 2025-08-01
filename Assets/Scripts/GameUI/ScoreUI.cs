using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

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
        //���� ������ �ʱ�ȭ
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
