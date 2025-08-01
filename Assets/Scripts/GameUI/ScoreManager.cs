using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }

    public static event System.Action<int> OnScoreChanged;

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
        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }

    public void ResetScore()
    {
        Score = 0;
        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }
}
