using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        ScoreManager.Instance.LoadBestScore();
        UpdateBestScoreText(ScoreManager.Instance.BestScore);
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

            UpdateBestScoreText(ScoreManager.Instance.BestScore);

        }

    }

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateScoreText;
        //ScoreManager.OnBestScoreChanged += UpdateBestScoreText; //����
        Health.OnPlayerDead += () => UpdateBestScoreText(ScoreManager.Instance.BestScore);
    }
  
        
    
    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= UpdateScoreText;
        //ScoreManager.OnBestScoreChanged -= UpdateBestScoreText; //����
        Health.OnPlayerDead -= () => UpdateBestScoreText(ScoreManager.Instance.BestScore);
    }

    private void UpdateScoreText(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"{newScore}";
        }
    }
    private void UpdateBestScoreText(int newScore)
    {
        if (bestScoreText != null)
        {
            bestScoreText.text = $"{newScore}";
        }
    }
}
