using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 30; // 입힐 데미지량

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Debug.Log($"{damage}의 데미지!"); 


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

