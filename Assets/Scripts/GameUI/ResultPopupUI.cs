using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class ResultPopupUI : MonoBehaviour
{
    public GameObject popupPanel;   // �˾� �г�
    public TextMeshProUGUI timeText;           // ���� �ð� �ؽ�Ʈ
    public TextMeshProUGUI scoreText;          // ���� ���� �ؽ�Ʈ

    // Inspector���� Timer�� ScoreManager�� ���� �������ִ� ���� �� �������Դϴ�.
    public Timer timer;

    private bool isResultShown = false; // ���â�� �̹� ǥ�õǾ����� Ȯ��

    private void Start()
    {
        if (popupPanel == null || timeText == null || scoreText == null || timer == null)
        {
            Debug.LogError("ResultPopupUI: �ʿ��� ���۷����� �������� �ʾҽ��ϴ�.");
            enabled = false;
            return;
        }
        popupPanel.SetActive(false); // ���� �� �˾� ��Ȱ��ȭ
    }

    private void OnEnable()
    {
        Timer.TimeUp += ShowResult;    // �ð� ���� ��
        Health.PlayerDead += ShowResult; // ��� ��
    }

    private void OnDisable()
    {
        Timer.TimeUp -= ShowResult;
        Health.PlayerDead -= ShowResult;
    }

    private void ShowResult()
    {
        // ���â�� �� �� �ߴ� ���� ����
        if (isResultShown) return;
        isResultShown = true;

        // ���� �ð� ����
        Time.timeScale = 0f;

        popupPanel.SetActive(true);

        // ���� �ð� ǥ��
        float t = timer.CurrentTime;
        timeText.text = $"Time Left: {Mathf.FloorToInt(t / 60):00}:{Mathf.FloorToInt(t % 60):00}";

        // ���� ���� ǥ��
        scoreText.text = $"Score: {ScoreManager.Instance.Score}";
    }
}
