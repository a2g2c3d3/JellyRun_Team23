using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameSceneManager;


public class GameOverUI : MonoBehaviour
{
    public Button Button;

    public void Start()
    {

    }

    public void RestartSceneLoadButton()
    {
        ScoreManager.Instance.SaveBestScore();
        Time.timeScale = 1f; // 시간 정지 해제
        ScoreManager.Instance.LoadBestScore();
        LoadScene(GameScene.MainScene);
        Debug.Log(ScoreManager.Instance.BestScore);
    }

    public void LobySceneLoadButton()
    {
        ScoreManager.Instance.SaveBestScore();
        Time.timeScale = 1f; // 시간 정지 해제
        ScoreManager.Instance.LoadBestScore();
        LoadScene(GameScene.LobyScene);
        Debug.Log(ScoreManager.Instance.BestScore);
    }
}
