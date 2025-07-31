using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    //private PatternManager _pattern;
    public Transform player;          // 플레이어 Transform
    public float patternSpacing = 15f;  // 플레이어보다 얼마나 뒤에 생성할지


    void Start()
    {
        // _pattern = FindObjectOfType<PatternManager>(); // Pattern.cs를 씬에서 찾기

        // 최초 패턴 1개 생성
        // Vector3 startPos = new Vector2(20f, 0f); // 처음 위치 (원하는 위치로 바꿔도 됨)
        // SpawnNewRandomPattern(startPos);
    }

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

            //// 플레이어 기준 위치 계산
            //float spawnX = player.position.x + patternSpacing;
            //Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

            //SpawnNewRandomPattern(spawnPos);
        }
    }

    //private void SpawnNewRandomPattern(Vector3 position)  //일정한가격마다 랜덤한 패턴이 나오게함
    //{
    //    if (_pattern == null || _pattern.patternPrefabs.Length == 0)
    //    {
    //        Debug.LogWarning("패턴 프리팹이 비어있음!");
    //        return;
    //    }

    //    int rand = Random.Range(0, _pattern.patternPrefabs.Length);
    //    Instantiate(_pattern.patternPrefabs[rand], position, Quaternion.identity); //패턴중 랜덤하게 하나를, position에, 회전없이
    //}

    //public void DecreasePatternSpacing()  // 스테이지가 증가할수록 패턴의 빈도가 점점 늘어나게
    //{
    //    patternSpacing = Mathf.Max(5f, patternSpacing - 2f);
    //}
}

