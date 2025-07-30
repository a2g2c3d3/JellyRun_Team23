using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class HPItem : BaseItem
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                ChangeHP(10);
                Destroy(gameObject);
            }
        }

        public override void ChangeHP(int HP)
        {
            //player.hp += 10; 플레이어 체력 증가
            //따로 UI에 Health 관련이 있다면 거기서 속성값 가져와서 변경
        }
    }
}