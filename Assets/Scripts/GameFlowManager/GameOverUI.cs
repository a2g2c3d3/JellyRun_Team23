using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameSceneManager;


public class GameOverUI : MonoBehaviour
{

    public void RestartSceneLoadButton()
    {
        LoadScene(GameScene.MainScene);
    }

    public void LobySceneLoadButton()
    {
        LoadScene(GameScene.LobyScene);
    }
}
