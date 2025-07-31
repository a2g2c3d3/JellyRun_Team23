using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameSceneManager;

public class SceneChanger : MonoBehaviour
{
    public Button MainGamebutton;
    public Button shopbutton;
    public Button exitbutton;
    public Animator animator;
    public float delayBeforeLoad = 2f;


    private void Awake()
    {
        animator.SetTrigger("LobyStartTrigger");
    }
    void Start()
    {
        MainGamebutton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.MainScene));
        shopbutton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.ShopScene));
        //exitbutton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.ShopScene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnButtonClicked(string triggerName,GameScene targetScene)
    {
        animator.SetTrigger(triggerName);
        StartCoroutine(LoadMainSceneWithDelay(targetScene));
    }
    IEnumerator LoadMainSceneWithDelay(GameScene scene)
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        LoadScene(scene);
    }

}
