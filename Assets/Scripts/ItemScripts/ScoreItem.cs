using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class ScoreItem : BaseItem
    {
        private void OnTriggerEnter2D(Collider2D collision)     //충돌하면 체력회복함수 실행
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