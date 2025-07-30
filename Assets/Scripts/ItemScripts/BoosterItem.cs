using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Item
{
    public class BoosterItem : MonoBehaviour
    {
        public PlayerMovement playerMovement;
        public SpriteRenderer SpriteRenderer;
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
            playerMovement.speed += speed;
            //���� ������� ����� ����ٸ� �߰����ֱ� �ִϸ����Ϳ��� �Ķ���� ����� �߰� �� �ָ� �� �� ����
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            playerMovement.speed -= speed;
        }
    }
}