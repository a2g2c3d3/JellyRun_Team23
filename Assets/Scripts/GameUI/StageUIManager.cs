using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

/// <summary>
/// 스테이지 UI 전체를 관리하는 클래스
/// - 타이머, 시작/클리어 텍스트, 결과창, 팝업 UI 포함
/// - 점수는 플레이 중 외부에서 추가됨 (예: 젤리 획득)
/// </summary>
public class StageUIManager : MonoBehaviour
{
    public static StageUIManager Instance { get; private set; }

    [Header("스테이지 설정")]
    [SerializeField] private float[] stageDurations = { 30f, 30f, 30f, 30f }; // 스테이지별 시간(초). Inspector에서 개수와 시간 조절 가능
    [Header("현재 상태")]
    [SerializeField] private int currentStage;
    [SerializeField] private float totalTimeRemaining;


    public int CurrentStage => currentStage;
    public float TotalTimeRemaining => totalTimeRemaining;

    // --- 이벤트 선언 ---
    public static event System.Action<int> OnStageStart;
    public static event System.Action OnGameClear;
    public static event System.Action<float> OnTotalProgressUpdate;

    public static Action OnGameFinished;

    private float totalGameTime; // 게임 전체 시간을 저장할 변수

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 총 게임 시간을 미리 계산
        totalGameTime = 0;
        foreach (float duration in stageDurations)
        {
            totalGameTime += duration;
        }
    }

     public void ShowResultPanel()
    {
        // 결과창을 띄우는 기능 수행
    }

    private void Start()
    {
        OnGameFinished += ShowResultPanel;
        // 게임 시작 시 시간 초기화 및 스테이지 진행 코루틴 시작
        totalTimeRemaining = totalGameTime;
        StartCoroutine(RunGameStages());
    }

    private IEnumerator RunGameStages()
    {
        // 배열의 길이를 총 스테이지 수로 사용
        for (int i = 0; i < stageDurations.Length; i++)
        {
            // 1. private 변수 currentStage에 값을 할당
            currentStage = i + 1; // 스테이지 번호는 1부터 시작

            // 스테이지 시작 이벤트 호출
            if (OnStageStart != null)
            {
                // 2. 이벤트 호출 시에도 private 변수 currentStage 사용
                OnStageStart(currentStage);
            }

            // 현재 스테이지에 맞는 시간을 배열에서 가져옴
            float stageTimer = stageDurations[i];
            while (stageTimer > 0)
            {
                // Time.timeScale의 영향을 받도록 Time.deltaTime 사용
                stageTimer -= Time.deltaTime;
                totalTimeRemaining -= Time.deltaTime;

                // 전체 진행도(1.0 -> 0.0)를 계산하여 이벤트 호출
                float progress = Mathf.Clamp01(totalTimeRemaining / totalGameTime);
                if (OnTotalProgressUpdate != null)
                {
                    OnTotalProgressUpdate(progress);
                }

                yield return null; // 다음 프레임까지 대기
            }
        }

        // --- 모든 스테이지 완료 ---
        // 게임 클리어 이벤트 호출
        if (OnGameClear != null)
        {
            OnGameClear();
        }

        // 클리어 텍스트를 보여주기 위해 2초 대기
        yield return new WaitForSeconds(2f);

        // 게임 완전 종료 이벤트 호출 (결과창 표시 트리거)
        if (OnGameFinished != null)
        {
            OnGameFinished();
        }
    }
}

