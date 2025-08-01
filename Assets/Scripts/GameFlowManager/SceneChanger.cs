using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameSceneManager;

public class SceneChanger : MonoBehaviour
{
    public Button mainGameButton;
    public Button shopButton;
    public Button lobyButton;
    public Button exitButton;
    public Animator animator;
    public float delayBeforeLoad = 2f;


    private void Awake()
    {
        animator.SetTrigger("LobyStartTrigger");
    }
    void Start()
    {
        mainGameButton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.MainScene));
        shopButton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.ShopScene));
        lobyButton.onClick.AddListener(() => OnButtonClicked("LobyRunTrigger", GameScene.LobyScene));
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
