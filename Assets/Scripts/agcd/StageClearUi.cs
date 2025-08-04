using JetBrains.Annotations;
using Player;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageClearUi : MonoBehaviour
{
    public PlayerMovement _player;
    public TextMeshProUGUI[] textMeshProUGUI;
    [SerializeField] private GameObject[] popupPanel;
    private int stageNum = 0;
    private bool stageChanged = false;

    void Start()
    {
        OffShowStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (StageManager.Instance.stageTimer == 30 && !stageChanged && stageNum < 5)
        {
            ChangeStage();
            stageChanged = true;
        }

        // stageTimer가 30이 아닐 때는 다시 실행 가능하게 만듦
        if (StageManager.Instance.stageTimer != 30)
        {
            stageChanged = false;
        }
    }


    public void ChangeStage()
    {
        stageNum++;
        Debug.LogError(stageNum);

        if (stageNum == 5)
        {
            textMeshProUGUI[stageNum - 1].text = "Endless Stage";
            ShowStage();

        }
        else
        {
            textMeshProUGUI[stageNum - 1].text = "Stage " + stageNum;
            ShowStage();
        }
        Invoke("OffShowStage", 2f);
        return;
    }

    public void ShowStage()
    {
        AudioListener.pause = true;
        popupPanel[stageNum - 1].SetActive(true);
        textMeshProUGUI[stageNum - 1].gameObject.SetActive(true);

        _player.speed = 25;
        PatternManager.Instance.timer = 3;

    }

    public void OffShowStage()
    {
        AudioListener.pause = false;
        foreach (GameObject stageNum in popupPanel)
        {
            stageNum.SetActive(false);
        }
        if (_player.speed == 25)
            _player.speed = 5 + (stageNum * 2);
    }

}
