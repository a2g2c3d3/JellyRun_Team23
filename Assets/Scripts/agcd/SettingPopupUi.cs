using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���� ���ӽ����̽� �߰�
using TMPro;
using System;
using Unity.VisualScripting;
using System.Linq.Expressions; // TextMeshPro ���ӽ����̽� �߰�

public class SettingPopupUi : MonoBehaviour
{
    public static SettingPopupUi Instance;

    [Header("UI ���")]
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
