using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private TextMeshProUGUI stageAnnounceText;    // 중앙 스테이지 안내 텍스트
    [SerializeField] private TextMeshProUGUI gameClearText;        // 게임 클리어 텍스트
    [SerializeField] private Slider stageProgressSlider;           // 전체 진행도 슬라이더
    [SerializeField] private Animator stageAnnounceAnimator;       // 안내 텍스트 애니메이터

    private void Start()
    {
        // 시작 시 UI 초기 상태 설정
        if (stageAnnounceText != null) stageAnnounceText.gameObject.SetActive(false);
        if (gameClearText != null) gameClearText.gameObject.SetActive(false);
        if (stageProgressSlider != null) stageProgressSlider.value = 1;
    }

    private void OnEnable()
    {
        // 이벤트 구독
        StageUIManager.OnStageStart += HandleStageStart;
        StageUIManager.OnGameClear += HandleGameClear;
        StageUIManager.OnTotalProgressUpdate += HandleProgressUpdate;
    }

    private void OnDisable()
    {
        // 이벤트 구독 해제
        StageUIManager.OnStageStart -= HandleStageStart;
        StageUIManager.OnGameClear -= HandleGameClear;
        StageUIManager.OnTotalProgressUpdate -= HandleProgressUpdate;
    }

    // 스테이지 시작 시 호출될 함수
    private void HandleStageStart(int stageNumber)
    {
        if (stageAnnounceText == null) return;

        stageAnnounceText.gameObject.SetActive(true);
        stageAnnounceText.text = $"Stage {stageNumber}";

        // 애니메이터가 있다면 "Show" 트리거를 발동시켜 애니메이션 재생
        if (stageAnnounceAnimator != null)
        {
            stageAnnounceAnimator.SetTrigger("Show");
        }
    }

    // 게임 클리어 시 호출될 함수
    private void HandleGameClear()
    {
        if (gameClearText != null)
        {
            gameClearText.gameObject.SetActive(true);
        }
    }

    // 진행도 슬라이더 업데이트 함수
    private void HandleProgressUpdate(float progress)
    {
        if (stageProgressSlider != null)
        {
            stageProgressSlider.value = progress;
        }
    }
}
