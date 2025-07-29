using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class BoosterItem : MonoBehaviour
    {
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
            Speed += speed;
            yield return new WaitForSeconds(3f);
            Speed -= speed;
        }
    }
}