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
        public PlayerMovement playerMovement;       //값 변경이 필요한 스크립트 접근할 변수들
        public SpriteRenderer SpriteRenderer;
        public ScoreTestScript testScore;
        
        public EffectType type;                     //인스펙터창 에서 타입 설정하기
        public int Effect;

        private void Awake()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
            testScore = FindObjectOfType<ScoreTestScript>();
        }

        /**충돌시 값을 변경할 함수 실행*/
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
 
                GetEfeectType();
            }
        }

        /**타입별로 아이템을 나눠서 실행 할 함수 결정*/
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

        /**체력 변경 로직*/
        protected void ChangeHP()
        {
            testScore.hp += Effect;
            Debug.Log($"현재 체력 {testScore.hp}");
            this.gameObject.SetActive(false);
            //TODO : 나중에 UI랑 연결 해줘야함 로직은 스코어랑 동일
        }

        /**점수 변경 로직*/
        protected void AddScore()
        {
            testScore.score += Effect;      //TODO : 나중에 UI랑 연결해줘야함
            if (playerMovement.speed < 15)
            {
                playerMovement.speed = testScore.score % 5 == 0 ? playerMovement.speed + 1 : playerMovement.speed; // 점수 5점 마다 속도 0.5 증가 로직
            }
            Debug.Log($"현재 점수 {testScore.score}");
            this.gameObject.SetActive(false);
        }

        /**속도 변경 로직*/
        protected IEnumerator ChangeSpeed()
        {
            float beforeSpeed = playerMovement.speed;
            playerMovement.speed = 25;
            //만약 사라지는 모션이 생긴다면 추가해주기 애니메이터에서 파라미터 만들어 추가 해 주면 될 것 같음
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            playerMovement.speed = beforeSpeed; //부스터 중복 획득 불가능 하게 설정 할 경우 if문을 통해 처리 가능해보임 
            yield return null;
        }
    }
}
