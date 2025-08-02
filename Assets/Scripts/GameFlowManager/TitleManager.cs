using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class TitleManager : MonoBehaviour
{
    private Animator animator;
    private float delay = 2f;
    private bool IsLoading = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.anyKey && !IsLoading)
        {
            IsLoading = true;
            animator.SetTrigger("TitlePlayerRunTrigger");
            StartCoroutine(LoadSceneWithDelay(GameScene.LobyScene));
        }   
    }


    IEnumerator LoadSceneWithDelay(GameScene Scene)
    {
        yield return new WaitForSeconds(delay);
        GameSceneManager.LoadScene(Scene);

    }
}
