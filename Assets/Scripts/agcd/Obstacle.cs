using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public PlayerMovement player; //플레이어 속도 받아오기
    private Health hp; //체력 가져오기

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>(); //플레이어 오브젝트 가져오기
        hp = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        {
           
            if (player.speed != 25)
            {
                AudioManager.instance.CrushSound(); //사운드

                player.speed = 5f; //기본속도로 돌려놓기
                hp.TakeDamage(20);
                player.Damage();
                StageManager.Instance.KnockbackTime();
                PatternManager.Instance.ResetSpawnTime();
            }
        }
        

        //if (collision.CompareTag("Player"))
        //{
        //    PlayerHealth hp = collision.GetComponent<PlayerHealth>();
        //    if (hp != null)
        //    {
        //        hp.TakeDamage(damage);
        //    }
        //}
    }
}

