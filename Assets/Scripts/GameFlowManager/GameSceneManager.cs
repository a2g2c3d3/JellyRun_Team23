using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public enum GameScene { 
        MainScene,
        LobyScene,
        ShopScene,
        GameOverScene
    }

    public static void LoadScene(GameScene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
