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
        //public Player player; 캐릭터 컴퍼넌트 받아오기
        int Speed;  //TODO 나중에 컴퍼넌트 받아오면 컴퍼넌트로 변경 할 예정


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("닿음");
            if (collision.CompareTag("Player"))
            {
                Debug.Log($"처음속도 {Speed}");
                StartCoroutine(ChangeSpeed(10));
                Debug.Log($"코루틴 후 속도 {Speed}");
            }
        }

        public virtual IEnumerator ChangeSpeed(int speed)       //StartCoroutine(ChangeSpeed(원하는숫자)); 이런식으로 코루틴 사용해야 함
        {
            playerMovement.speed += speed;
            //만약 사라지는 모션이 생긴다면 추가해주기 애니메이터에서 파라미터 만들어 추가 해 주면 될 것 같음
            SpriteRenderer.gameObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            playerMovement.speed -= speed;
        }
    }
}