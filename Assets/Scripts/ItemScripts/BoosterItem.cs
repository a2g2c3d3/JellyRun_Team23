using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class BoosterItem : MonoBehaviour
    {
        //public Player player; ĳ���� ���۳�Ʈ �޾ƿ���
        int Speed;  //TODO ���߿� ���۳�Ʈ �޾ƿ��� ���۳�Ʈ�� ���� �� ����

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("����");
            if (collision.CompareTag("Player"))
            {
                Debug.Log($"ó���ӵ� {Speed}");
                StartCoroutine(ChangeSpeed(10));
                Debug.Log($"�ڷ�ƾ �� �ӵ� {Speed}");
            }
        }

        public virtual IEnumerator ChangeSpeed(int speed)       //StartCoroutine(ChangeSpeed(���ϴ¼���)); �̷������� �ڷ�ƾ ����ؾ� ��
        {
            Speed += speed;
            yield return new WaitForSeconds(3f);
            Speed -= speed;
        }
    }
}