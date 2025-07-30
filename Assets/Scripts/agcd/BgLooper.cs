using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 4;
    private Pattern _pattern;
    public Transform player;          // 플레이어 Transform
    public float patternSpawnOffset = 15f;  // 플레이어보다 몇 거리 뒤에 생성할지

    void Start()
    {
        _pattern = FindObjectOfType<Pattern>(); // Pattern.cs를 씬에서 찾기

        // 최초 패턴 1개 생성
        Vector3 startPos = new Vector2(20f, 0f); // 처음 위치 (원하는 위치로 바꿔도 됨)
        SpawnNewRandomPattern(startPos);
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

            // 플레이어 기준 위치 계산
            float spawnX = player.position.x + patternSpawnOffset;
            Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

            SpawnNewRandomPattern(spawnPos);
        }
    }

    private void SpawnNewRandomPattern(Vector3 position)
    {
        if (_pattern == null || _pattern.patternPrefabs.Length == 0)
        {
            Debug.LogWarning("패턴 프리팹이 비어있음!");
            return;
        }

        int rand = Random.Range(0, _pattern.patternPrefabs.Length);

        float spawnX = player.position.x + patternSpawnOffset;
        Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

        Instantiate(_pattern.patternPrefabs[rand], spawnPos, Quaternion.identity);
    }
}

