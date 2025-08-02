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
    public TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private GameObject popupPanel;
    private int stageNum = 0;
    private float beforeSpeed;

    void Start()
    {
        
        OffShowStage();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStage();

    }


    public void ChangeStage()
    {
        if (StageManager.Instance.stageTimer == 30)
        {
            
            
            stageNum++;
            textMeshProUGUI.text = "Stage " + stageNum;
            ShowStage();
            Invoke("OffShowStage", 2f);
        }
        return;
    }

    public void ShowStage()
    {
        popupPanel.SetActive(true);
        textMeshProUGUI.gameObject.SetActive(true);
        beforeSpeed = _player.speed;
        _player.speed = 25;
        PatternManager.Instance.timer = 3;

    }
    public void OffShowStage()
    {
        popupPanel.SetActive(false);
        textMeshProUGUI.gameObject.SetActive(false);

        if(_player.speed == 25)
        _player.speed = beforeSpeed;
    }

}
