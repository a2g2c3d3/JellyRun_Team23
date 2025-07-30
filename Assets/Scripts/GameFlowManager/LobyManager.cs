using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameSceneManager;

public class LobyManager : MonoBehaviour
{
    public Button button;
    public Animator animator;
    public float delayBeforeLoad = 2f;


    private void Awake()
    {
        animator.SetTrigger("LobyStartTrigger");
    }
    void Start()
    {
        button.onClick.AddListener(GameStartButton);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void GameStartButton()
    {
        animator.SetTrigger("LobyRunTrigger");
        StartCoroutine(LoadMainSceneWithDelay());
    }
    IEnumerator LoadMainSceneWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        LoadScene(GameScene.MainScene);
    }

}
