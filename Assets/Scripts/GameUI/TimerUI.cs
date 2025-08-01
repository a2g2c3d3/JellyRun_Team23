using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro;

public class TimerUI : MonoBehaviour
{
    public Timer timer;             // Timer ���۷���
    public TextMeshProUGUI timeText;           // M:SS �ؽ�Ʈ

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


        // �ʱ� �ð� ǥ��
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
            // ���� �ð��� �а� �ʷ� ��ȯ�Ͽ� ǥ��
            int minutes = Mathf.FloorToInt(current / 60f);
            int seconds = Mathf.FloorToInt(current % 60f);
            timeText.text = $"{minutes:0}:{seconds:00}";
        }
    }
}
