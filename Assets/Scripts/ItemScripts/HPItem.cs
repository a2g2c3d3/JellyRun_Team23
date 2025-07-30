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
            //player.hp += 10; �÷��̾� ü�� ����
            //���� UI�� Health ������ �ִٸ� �ű⼭ �Ӽ��� �����ͼ� ����
        }
    }
}