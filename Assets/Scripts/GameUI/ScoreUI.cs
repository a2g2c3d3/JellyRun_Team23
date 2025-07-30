using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ���� ǥ�� �ؽ�Ʈ

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("ScoreUI: �ؽ�Ʈ ���۷����� �����ϴ�.");
            enabled = false;
            return;
        }
        // ������ �� ���� ������ UI �ʱ�ȭ
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
