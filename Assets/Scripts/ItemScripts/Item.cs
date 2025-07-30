using Item;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public enum EffectType
    {
        hp,
        speed,
        score,
    }

    public class Item : MonoBehaviour
    {
        public PlayerMovement playerMovement;       //�� ������ �ʿ��� ��ũ��Ʈ ������ ������
        public SpriteRenderer SpriteRenderer;
        public ScoreTestScript testScore;
        
        public EffectType type;                     //Ÿ�� ��������
        public int Effect;                          

        /**�浹�� ���� ������ �Լ� ����*/
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                GetEfeectType();
            }
        }

        /**Ÿ�Ժ��� �������� ������ ���� �� �Լ� ����*/
        protected void GetEfeectType()      
        {
            switch (type)
            {
                case EffectType.hp:
                    break;
                case EffectType.speed:
                    StartCoroutine(ChangeSpeed());
                    break;
                case EffectType.score:
                    AddScore();
                    break;
            }
        }

        /**ü�� ���� ����*/
        protected void ChangeHP(int hp)
        {

        }

        /**���� ���� ����*/
        protected void AddScore()
        {
            testScore.score += Effect;
            Debug.Log($"���� ���� {testScore.score}");
            this.gameObject.SetActive(false);
        }

        /**�ӵ� ���� ����*/
        protected IEnumerator ChangeSpeed()
        {
            playerMovement.speed += Effect;
            //���� ������� ����� ����ٸ� �߰����ֱ� �ִϸ����Ϳ��� �Ķ���� ����� �߰� �� �ָ� �� �� ����
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            playerMovement.speed -= Effect; //�ν��� �ߺ� ȹ�� �Ұ��� �ϰ� ���� �� ��� if���� ���� ó�� �����غ��� 
        }
    }
}
