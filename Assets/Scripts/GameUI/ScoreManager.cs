using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; set; }
    public int Score { get; private set; }
    public int BestScore { get; set; }
    public string BestScoreKey = "BestScore";
    public bool isBestScore;

    public static event System.Action<int> OnScoreChanged;
    public static event System.Action<int> OnBestScoreChanged;

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
        isBestScore = false;
    }

    private void OnDestroy()
    {
        SaveBestScore();
    }


    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChanged?.Invoke(Score);
        if (Score >= BestScore) 
        {
            isBestScore = true;
        }
    }

    public void LoadBestScore()
    {
        BestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        OnBestScoreChanged?.Invoke(BestScore);
        Debug.Log(PlayerPrefs.GetInt(BestScoreKey, 0));
    }


    public void SaveBestScore()
    {
        int previous = PlayerPrefs.GetInt(BestScoreKey, 0);

        if (Score > previous)
        {
            BestScore = Score;
            PlayerPrefs.SetInt(BestScoreKey, BestScore);
            PlayerPrefs.Save();

            OnBestScoreChanged?.Invoke(BestScore); //  ¿Ã∞≈ ≤¿!
        }
    }
}
