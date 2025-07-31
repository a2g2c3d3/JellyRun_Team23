using System;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public GameObject[] stagePrefabs;       // Stage1, Stage2, ... �����յ�
    public float stageDuration = 10f;       // �������� ��ȯ �ð�
    public float stageSpacing = 15f;
    public Transform player;


    private int currentStageIndex = 0;
    private float timer;
    private GameObject currentStageInstance;


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
            Debug.Log("�������� ����!");

            // ���� �������� ����
            if (currentStageInstance != null)
            {
              
                Destroy(currentStageInstance, 2f);
            }

            currentStageIndex++;
            timer = stageDuration;

            if (currentStageIndex < stagePrefabs.Length)
            {
                SpawnNextStage(currentStageIndex);
            }
            else
            {
                Debug.Log("��� �������� �Ϸ�!");
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
        currentStageInstance = Instantiate(stagePrefabs[index], spawnPos , Quaternion.identity);
    }
}