using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] stagePrefabs;       // Stage1, Stage2, ... �����յ�
    public float stageDuration = 30f;       // �������� ��ȯ �ð�
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
                Debug.Log("��� �������� �Ϸ�!");
            }
        }
    }

    void SpawnStage(int index)
    {
        Instantiate(stagePrefabs[index], Vector3.zero, Quaternion.identity);
    }
}