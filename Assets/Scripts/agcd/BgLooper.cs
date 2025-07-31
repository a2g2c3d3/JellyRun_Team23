using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    //private PatternManager _pattern;
    public Transform player;          // �÷��̾� Transform
    public float patternSpacing = 15f;  // �÷��̾�� �󸶳� �ڿ� ��������


    void Start()
    {
        // _pattern = FindObjectOfType<PatternManager>(); // Pattern.cs�� ������ ã��

        // ���� ���� 1�� ����
        // Vector3 startPos = new Vector2(20f, 0f); // ó�� ��ġ (���ϴ� ��ġ�� �ٲ㵵 ��)
        // SpawnNewRandomPattern(startPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
            Destroy(collision.gameObject);

            //// �÷��̾� ���� ��ġ ���
            //float spawnX = player.position.x + patternSpacing;
            //Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

            //SpawnNewRandomPattern(spawnPos);
        }
    }

    //private void SpawnNewRandomPattern(Vector3 position)  //�����Ѱ��ݸ��� ������ ������ ��������
    //{
    //    if (_pattern == null || _pattern.patternPrefabs.Length == 0)
    //    {
    //        Debug.LogWarning("���� �������� �������!");
    //        return;
    //    }

    //    int rand = Random.Range(0, _pattern.patternPrefabs.Length);
    //    Instantiate(_pattern.patternPrefabs[rand], position, Quaternion.identity); //������ �����ϰ� �ϳ���, position��, ȸ������
    //}

    //public void DecreasePatternSpacing()  // ���������� �����Ҽ��� ������ �󵵰� ���� �þ��
    //{
    //    patternSpacing = Mathf.Max(5f, patternSpacing - 2f);
    //}
}

