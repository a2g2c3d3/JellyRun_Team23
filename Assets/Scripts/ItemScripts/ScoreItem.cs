using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ScoreItem : BaseItem
    {
        private void OnTriggerEnter2D(Collider2D collision)     //�浹�ϸ� ü��ȸ���Լ� ����
        {
            if (collision.CompareTag("Player"))
            {
                AddScore(1);
            }
        }

        public override void AddScore(int score)
        {
            //int numscore = 
            //ui.score.text += (string)0.5f; 
        }
    }
}