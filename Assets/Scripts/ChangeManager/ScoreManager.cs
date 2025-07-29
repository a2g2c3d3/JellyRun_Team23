using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;      //싱글톤

        string character;   // 캐릭터 클래스 받아올 속성 미리 만들어두기 앞에 string은 나중에 바꿔줄 것
        public float changeSpeed;          // 변경 할 값 저장
        public int changeHealthPoint;
        public int changeScore;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;  // 현재 컴포넌트 자체를 싱글톤으로 등록
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            //character = GetComponent<Character>(); 이걸로 속성 메서드들 가져오기
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("속도증가"))
            {
                changeSpeed += 0.5f;
                //속도 증가 로직
            }
            if (collision.CompareTag("장애물"))
            {
                changeSpeed -= 0.5f;
                //속도 감소 로직
            }
            if (collision.CompareTag("체력회복"))
            {
                changeHealthPoint += 10;
                //체력 회복 로직
            }
            if (collision.CompareTag("점수획득"))
            {
                changeScore += 10;
                //점수 추가 로직
            }
            
        }
        //캐릭터에 아이템 접촉 메서드 혹은 속성을 가지고 와서 접촉 물체에 따라 체력 혹은 점수 관리
    }
}
