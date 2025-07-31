using UnityEngine;

public class PatternManager : MonoBehaviour
{
    public GameObject[] patternPrefabs;
    public Transform player;
    public float patternSpacing = 15f;
    public float patternSpawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnPattern();
            timer = patternSpawnInterval;
        }
    }

    void SpawnPattern()
    {
        if (patternPrefabs.Length == 0) return;

        int rand = Random.Range(0, patternPrefabs.Length);
        float spawnX = player.position.x + patternSpacing;
        Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

        Instantiate(patternPrefabs[rand], spawnPos, Quaternion.identity);
    }

    public void DecreaseSpacing()
    {
        patternSpacing = Mathf.Max(5f, patternSpacing - 2f);
    }

    public void DecreaseSpawnInterval()
    {
        patternSpawnInterval = Mathf.Max(1f, patternSpawnInterval - 0.5f);
    }
}