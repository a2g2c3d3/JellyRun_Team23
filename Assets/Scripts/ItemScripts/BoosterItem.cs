using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //player.speed += 0.5f; �÷��̾� Ȥ�� �ʿ� ���ǵ� �÷��ֱ� Ȥ�� ���� �޼��带 ���� �ڷ�ƾ���� �ٽ� �ٿ��� �� �� ����
            //�ӵ� ���� ����
        }
    }
}
