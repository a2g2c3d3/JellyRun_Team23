using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameSceneManager;

public class TitleManager : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public AudioSource audioSource;
    private float delay = 2f;

    private void Awake()
    {
        
    }
    private void Update()
    {
        if (Input.anyKey && player.localPosition.x >= 5)
        {
            Debug.Log("함수가실행됨");
            animator.SetTrigger("TitlePlayerRunTrigger");
            
            StartCoroutine(LoadSceneWithDelay(GameScene.LobyScene));
            audioSource.Play();
        }   
    }

    public void runToLobby()
    {

    }

    IEnumerator LoadSceneWithDelay(GameScene Scene)
    {
        yield return new WaitForSeconds(delay);
        GameSceneManager.LoadScene(Scene);

    }
}
