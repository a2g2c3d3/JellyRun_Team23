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
        ScoreManager.Instance.LoadBestScore();
        LoadScene(GameScene.MainScene);
    }

    public void LobySceneLoadButton()
    {
        Time.timeScale = 1f;
        ScoreManager.Instance.SaveBestScore();
        ScoreManager.Instance.LoadBestScore();
        LoadScene(GameScene.LobyScene);
    }
}
