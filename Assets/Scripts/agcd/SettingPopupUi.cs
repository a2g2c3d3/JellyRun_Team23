using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 네임스페이스 추가
using TMPro;
using System;
using Unity.VisualScripting;
using System.Linq.Expressions; // TextMeshPro 네임스페이스 추가

public class SettingPopupUi : MonoBehaviour
{
    public static SettingPopupUi Instance;

    [Header("UI 요소")]
    [SerializeField] private GameObject popupImage;

    public bool isSettingShown;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        isSettingShown = false;
        if (popupImage != null) popupImage.SetActive(false);
    }


    public void ShowSetting()
    {
        isSettingShown = !isSettingShown ? true : false;
        popupImage.SetActive(isSettingShown);
    }

}
