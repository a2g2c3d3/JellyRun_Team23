using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    public Transform player;          // 플레이어 Transform
    public float patternSpacing = 15f;  // 플레이어보다 얼마나 뒤에 생성할지


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount; //백그라운드의 수만큼 띄어서 다시 위치시킴
            collision.transform.position = pos;
            return;
        }

        if (collision.CompareTag("Pattern"))
        {
            Destroy(collision.gameObject);

          
        }
    }

    
}

