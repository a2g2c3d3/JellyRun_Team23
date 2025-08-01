using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public PlayerMovement player; //�÷��̾� �ӵ� �޾ƿ���
    public int damage = 30; // ���� ��������
    private Health hp; //ü�� ��������

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>(); //�÷��̾� ������Ʈ ��������
        hp = FindObjectOfType<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        {
           
            if (player.speed != 25)
            {
                player.speed = 5f; //�⺻�ӵ��� ��������
                hp.TakeDamage(20);
                player.Damage();
                Debug.Log($"{damage}�� ������!");
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

