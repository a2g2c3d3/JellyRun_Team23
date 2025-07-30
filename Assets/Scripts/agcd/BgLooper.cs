using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    public int numPtCount = 1;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision) // 충돌에 대한 통보만 해주기때문에 부딪친 충돌체에대한 정보만 줌
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
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numPtCount;
            collision.transform.position = pos;
            return; 
        }

    }

}