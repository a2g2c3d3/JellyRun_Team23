using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro; // TextMeshPro 네임스페이스 추가

public class ResultPopupUI : MonoBehaviour
{
    public GameObject popupPanel;   // 팝업 패널
    public TextMeshProUGUI timeText;           // 남은 시간 텍스트
    public TextMeshProUGUI scoreText;          // 최종 점수 텍스트

    // Inspector에서 Timer와 ScoreManager를 직접 연결해주는 것이 더 안정적입니다.
    public Timer timer;

    private bool isResultShown = false; // 결과창이 이미 표시되었는지 확인

    private void Start()
    {
        if (popupPanel == null || timeText == null || scoreText == null || timer == null)
        {
            Debug.LogError("ResultPopupUI: 필요한 레퍼런스가 설정되지 않았습니다.");
            enabled = false;
            return;
        }
        popupPanel.SetActive(false); // 시작 시 팝업 비활성화
    }

    private void OnEnable()
    {
        Timer.TimeUp += ShowResult;    // 시간 종료 시
        Health.PlayerDead += ShowResult; // 사망 시
    }

    private void OnDisable()
    {
        Timer.TimeUp -= ShowResult;
        Health.PlayerDead -= ShowResult;
    }

    private void ShowResult()
    {
        // 결과창이 두 번 뜨는 것을 방지
        if (isResultShown) return;
        isResultShown = true;

        // 게임 시간 정지
        Time.timeScale = 0f;

        popupPanel.SetActive(true);

        // 남은 시간 표시
        float t = timer.CurrentTime;
        timeText.text = $"Time Left: {Mathf.FloorToInt(t / 60):00}:{Mathf.FloorToInt(t % 60):00}";

        // 최종 점수 표시
        scoreText.text = $"Score: {ScoreManager.Instance.Score}";
    }
}
