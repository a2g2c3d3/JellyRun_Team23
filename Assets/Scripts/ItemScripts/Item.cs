using Item;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        private Health hp;
        
        public EffectType type;                     //�ν�����â ���� Ÿ�� �����ϱ�
        public int Effect;

        private void Awake()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            testScore = FindObjectOfType<ScoreTestScript>();
            hp = FindObjectOfType<Health>();
        }

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
                    ChangeHP();
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
        protected void ChangeHP()
        {
            hp.PlusHP(Effect);
            testScore.hp += Effect;
            this.gameObject.SetActive(false);
            //TODO : ���߿� UI�� ���� ������� ������ ���ھ�� ����
        }

        /**���� ���� ����*/
        protected void AddScore()
        {
            ScoreManager.Instance.AddScore(Effect);
            testScore.score += Effect;      //TODO : ���߿� UI�� �����������
            if (playerMovement.speed < 15)
            {
                playerMovement.speed = testScore.score % 5 == 0 ? playerMovement.speed + 1 : playerMovement.speed; // ���� 5�� ���� �ӵ� 0.5 ���� ����
            }
            this.gameObject.SetActive(false);
        }

        /**�ӵ� ���� ����*/
        protected IEnumerator ChangeSpeed()
        {
            StageManager.Instance.ApplyBooster();
            float beforeSpeed = playerMovement.speed;
            playerMovement.speed = 25;
            //���� ������� ����� ����ٸ� �߰����ֱ� �ִϸ����Ϳ��� �Ķ���� ����� �߰� �� �ָ� �� �� ����
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);


            float duration = 1.0f; // �ӵ��� ���̴� �� �ɸ� �ð�
            float elapsed = 0f;    // �����

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                playerMovement.speed = Mathf.Lerp(25f, beforeSpeed, elapsed / duration);
                yield return null;
            }

            playerMovement.speed = beforeSpeed; //Ȥ�� �𸣴ϱ� �� �ٽ� �־��ֱ�
        }
    }
}
