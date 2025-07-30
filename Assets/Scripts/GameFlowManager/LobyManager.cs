using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour
{
    public Button button;
    public Animator animator;


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
        SceneManager.LoadScene("MainScene");
        animator.SetTrigger("LobyRunTrigger");
    }

}
