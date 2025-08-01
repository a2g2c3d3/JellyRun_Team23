using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [Header("UI ���")]
    [SerializeField] private TextMeshProUGUI stageAnnounceText;    // �߾� �������� �ȳ� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI gameClearText;        // ���� Ŭ���� �ؽ�Ʈ
    [SerializeField] private Slider stageProgressSlider;           // ��ü ���൵ �����̴�
    [SerializeField] private Animator stageAnnounceAnimator;       // �ȳ� �ؽ�Ʈ �ִϸ�����

    private void Start()
    {
        // ���� �� UI �ʱ� ���� ����
        if (stageAnnounceText != null) stageAnnounceText.gameObject.SetActive(false);
        if (gameClearText != null) gameClearText.gameObject.SetActive(false);
        if (stageProgressSlider != null) stageProgressSlider.value = 1;
    }

    private void OnEnable()
    {
        // �̺�Ʈ ����
        StageUIManager.OnStageStart += HandleStageStart;
        StageUIManager.OnGameClear += HandleGameClear;
        StageUIManager.OnTotalProgressUpdate += HandleProgressUpdate;
    }

    private void OnDisable()
    {
        // �̺�Ʈ ���� ����
        StageUIManager.OnStageStart -= HandleStageStart;
        StageUIManager.OnGameClear -= HandleGameClear;
        StageUIManager.OnTotalProgressUpdate -= HandleProgressUpdate;
    }

    // �������� ���� �� ȣ��� �Լ�
    private void HandleStageStart(int stageNumber)
    {
        if (stageAnnounceText == null) return;

        stageAnnounceText.gameObject.SetActive(true);
        stageAnnounceText.text = $"Stage {stageNumber}";

        // �ִϸ����Ͱ� �ִٸ� "Show" Ʈ���Ÿ� �ߵ����� �ִϸ��̼� ���
        if (stageAnnounceAnimator != null)
        {
            stageAnnounceAnimator.SetTrigger("Show");
        }
    }

    // ���� Ŭ���� �� ȣ��� �Լ�
    private void HandleGameClear()
    {
        if (gameClearText != null)
        {
            gameClearText.gameObject.SetActive(true);
        }
    }

    // ���൵ �����̴� ������Ʈ �Լ�
    private void HandleProgressUpdate(float progress)
    {
        if (stageProgressSlider != null)
        {
            stageProgressSlider.value = progress;
        }
    }
}
