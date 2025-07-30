using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    public int numPtCount = 1;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision) // �浹�� ���� �뺸�� ���ֱ⶧���� �ε�ģ �浹ü������ ������ ��
    {
       
        if (collision.CompareTag("Background"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount; //��׶����� ����ŭ �� �ٽ� ��ġ��Ŵ
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