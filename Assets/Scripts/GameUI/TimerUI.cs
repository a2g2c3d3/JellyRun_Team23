using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro;

public class TimerUI : MonoBehaviour
{
    public Timer timer;             // Timer 레퍼런스
    public TextMeshProUGUI timeText;           // M:SS 텍스트

    private void Start()
    {
        if (timer == null || timeText == null)
        {
            enabled = false;
            return;
        }
    }

    private void OnEnable()
    {
        Timer.TimeChanged += UpdateDisplay;


        // 초기 시간 표시
        if (timer != null)
            UpdateDisplay(timer.CurrentTime, timer.playTime);
    }

    private void OnDisable()
    {
        Timer.TimeChanged -= UpdateDisplay;
    }

    private void UpdateDisplay(float current, float total)
    {

        if (timeText != null)
        {
            // 남은 시간을 분과 초로 변환하여 표시
            int minutes = Mathf.FloorToInt(current / 60f);
            int seconds = Mathf.FloorToInt(current % 60f);
            timeText.text = $"{minutes:0}:{seconds:00}";
        }
    }
}
