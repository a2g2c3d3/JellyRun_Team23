using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }

    // 이벤트: 점수 변경 시 (현재 점수)
    public delegate void OnScoreChanged(int newScore);
    public static event OnScoreChanged ScoreChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreChanged?.Invoke(Score); // 점수 변경 이벤트 호출
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
    }
}
