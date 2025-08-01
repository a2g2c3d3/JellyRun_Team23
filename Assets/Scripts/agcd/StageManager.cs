using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public GameObject[] stagePrefabs;       // Stage1, Stage2, ... 프리팹들
    public float stageDuration = 10f;       // 스테이지 전환 시간
    public float stageSpacing = 15f;
    public Transform player;
    public float TotalGameTime => stageDuration * stagePrefabs.Length;
    public float ElapsedTime => (currentStageIndex * stageDuration) + (stageDuration - timer);


    private int currentStageIndex = 0;
    [SerializeField] private float timer;
    private GameObject currentStageInstance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timer = stageDuration;

        SpawnStage(currentStageIndex);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Debug.Log("스테이지 변경!");

            // 이전 스테이지 제거
            if (currentStageInstance != null)
            {

                Destroy(currentStageInstance, 2f);
            }

            currentStageIndex++;
            timer = stageDuration;

            if (currentStageIndex < stagePrefabs.Length)
            {
                SpawnNextStage(currentStageIndex);
                FindObjectOfType<PatternManager>().DecreaseSpawnInterval();
            }
            else
            {
                Debug.Log("모든 스테이지 완료!");
            }
        }
    }

    void SpawnStage(int index)
    {
        currentStageInstance = Instantiate(stagePrefabs[index], Vector3.zero, Quaternion.identity);
    }

    void SpawnNextStage(int index)
    {
        float spawnX = player.position.x + stageSpacing;
        Vector3 spawnPos = new Vector3(spawnX, 0f, 0f);
        currentStageInstance = Instantiate(stagePrefabs[index], spawnPos, Quaternion.identity);
    }

    public void ApplyBooster()
    {
        //FindObjectOfType<StageProgressUi>().FlashBoosterEffect();
        timer -= 3f;
        if (timer < 0f) timer = 0f;
    }


}