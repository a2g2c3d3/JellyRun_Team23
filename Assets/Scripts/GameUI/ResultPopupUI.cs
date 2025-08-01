using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro; // TextMeshPro 네임스페이스 추가

public class ResultPopupUI : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isResultShown = false;

    private void Start()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
        // 게임 종료 이벤트 구독 (플레이어 사망 또는 시간 종료)
        //  이벤트 구독을 Start()에서 하도록 변경
        StageUIManager.OnGameFinished += ShowResult;
    }

    private void OnDestroy()
    {// 게임 종료 이벤트 구독 (플레이어 사망 또는 시간 종료)
        //  해제도 OnDisable 말고 OnDestroy로
        StageUIManager.OnGameFinished -= ShowResult;
    }

    //private void OnEnable()
    //{
    //    
    //    StageUIManager.OnGameFinished += ShowResult;
    //}

    //private void OnDisable()
    //{
    //    StageUIManager.OnGameFinished -= ShowResult;
    //}

    private void ShowResult()
    {
        if (isResultShown) return;
        isResultShown = true;

        popupPanel.SetActive(true);
        Time.timeScale = 0f;
        

        // 최종 점수 표시
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.Score}";
        }
        Debug.Log("구독 좋아요 알림설정");
    }

}
