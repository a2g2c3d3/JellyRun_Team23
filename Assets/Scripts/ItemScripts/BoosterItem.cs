using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //player.speed += 0.5f; 플레이어 혹은 맵에 스피드 올려주기 혹은 따로 메서드를 만들어서 코루틴으로 다시 줄여도 될 것 같음
            //속도 증가 로직
        }
    }
}
