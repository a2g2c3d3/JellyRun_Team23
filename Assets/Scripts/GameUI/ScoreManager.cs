using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    public int BestScore { get; private set; }

    private const string BestScoreKey = "BestScore";


    public static event System.Action<int> OnScoreChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadBestScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SaveBestScore();
    }


    public void AddScore(int amount)
    {
        Score += amount;
        if (OnScoreChanged != null)
        {
            BestScore = Score;
        }
    }

    private void LoadBestScore()
    {
        BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(BestScoreKey, BestScore);
        PlayerPrefs.Save(); // 변경 사항을 즉시 저장
    }
}
