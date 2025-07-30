using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision) // 충돌에 대한 통보만 해주기때문에 부딪친 충돌체에대한 정보만 줌
    {
        Debug.Log("Triggerd: " + collision.name); // 누구와 부딪쳤는지 확인

        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return; // 백그라운드라면 옵스타클이아닌걸 알기때문에
        }

      
    }

}