using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] stagePrefabs;       // Stage1, Stage2, ... 프리팹들
    public float stageDuration = 30f;       // 스테이지 전환 시간
    public PatternManager patternManager;

    private int currentStageIndex = 0;
    private float timer;

    private BgLooper bgLooper;

    void Start()
    {
        bgLooper = FindObjectOfType<BgLooper>();
        timer = stageDuration;

        SpawnStage(currentStageIndex);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            currentStageIndex++;
            timer = stageDuration;

            if (currentStageIndex < stagePrefabs.Length)
            {
                SpawnStage(currentStageIndex);
            }
            else
            {
                Debug.Log("모든 스테이지 완료!");
            }
        }
    }

    void SpawnStage(int index)
    {
        Instantiate(stagePrefabs[index], Vector3.zero, Quaternion.identity);
    }
}