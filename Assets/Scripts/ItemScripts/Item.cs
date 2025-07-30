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
        public PlayerMovement playerMovement;       //값 변경이 필요한 스크립트 접근할 변수들
        public SpriteRenderer SpriteRenderer;
        public ScoreTestScript testScore;
        
        public EffectType type;                     //타입 가져오기
        public int Effect;                          

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
        protected void ChangeHP(int hp)
        {

        }

        /**점수 변경 로직*/
        protected void AddScore()
        {
            testScore.score += Effect;
            Debug.Log($"현재 점수 {testScore.score}");
            this.gameObject.SetActive(false);
        }

        /**속도 변경 로직*/
        protected IEnumerator ChangeSpeed()
        {
            playerMovement.speed += Effect;
            //만약 사라지는 모션이 생긴다면 추가해주기 애니메이터에서 파라미터 만들어 추가 해 주면 될 것 같음
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            playerMovement.speed -= Effect; //부스터 중복 획득 불가능 하게 설정 할 경우 if문을 통해 처리 가능해보임 
        }
    }
}
