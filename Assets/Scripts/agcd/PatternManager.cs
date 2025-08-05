using UnityEngine;
using System.Collections;

public class PatternManager : MonoBehaviour
{
    public static PatternManager Instance;
    public GameObject[] patternPrefabs;
    public Transform player;
    private float patternSpacing = 15f;  //�÷��̾�� ���ϰ��� ����
    public float patternSpawnInterval = 10f; //������ �ֱ�

    [SerializeField] public float timer;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnPatternRoutine());
    }
    IEnumerator SpawnPatternRoutine()
    {
        while (true)
        {
            SpawnPattern();
            yield return new WaitForSeconds(patternSpawnInterval); // 2�� ����
        }
    }

    void Update()
    {
        //timer -= Time.deltaTime;
        //if (timer <= 0f)
        //{
        //    SpawnPattern();
        //    timer = patternSpawnInterval;
        //}
    }

    void SpawnPattern()
    {
        if (patternPrefabs.Length == 0) return;

        int rand = Random.Range(0, patternPrefabs.Length);
        float spawnX = player.position.x + patternSpacing;
        Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);

        Instantiate(patternPrefabs[rand], spawnPos, Quaternion.identity);
    }

    public void DecreaseSpawnInterval()
    {
        patternSpawnInterval = Mathf.Max(1f, patternSpawnInterval - 2.2f);
    }
    public void ResetSpawnTime()
    {
        timer = patternSpawnInterval;
    }
}