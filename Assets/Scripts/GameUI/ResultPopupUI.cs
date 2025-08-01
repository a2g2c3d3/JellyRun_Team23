using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro; // TextMeshPro ���ӽ����̽� �߰�

public class ResultPopupUI : MonoBehaviour
{
    [Header("UI ���")]
    [SerializeField] private GameObject popupPanel;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isResultShown = false;

    private void Start()
    {
        if (popupPanel != null) popupPanel.SetActive(false);
    }

    private void OnEnable()
    {
        // ���� ���� �̺�Ʈ ���� (�÷��̾� ��� �Ǵ� �ð� ����)
        StageUIManager.OnGameFinished += ShowResult;
    }

    private void OnDisable()
    {
        StageUIManager.OnGameFinished -= ShowResult;
    }

    private void ShowResult()
    {
        //if (isResultShown) return;
        isResultShown = true;

        if (popupPanel != null) popupPanel.SetActive(true);
        Time.timeScale = 0f;
        

        // ���� ���� ǥ��
        if (scoreText != null && ScoreManager.Instance != null)
        {
            scoreText.text = $"Score: {ScoreManager.Instance.Score}";
        }
    }

}
