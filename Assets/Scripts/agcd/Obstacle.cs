using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 30; // ���� ��������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Debug.Log($"{damage}�� ������!"); 


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

