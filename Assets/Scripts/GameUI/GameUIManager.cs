using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameSceneManager;


/// <summary>
/// 게임 내 버튼의 역할을 정의하는 열거형.
/// 버튼의 기능을 명확하게 구분하고 중앙 집중화하는 데 사용됩니다.
/// </summary>
public enum ButtonRole
{
    None,
    Restart,
    Lobby,
    ToggleSettings,
    TemporaryStop,
    Reset
}

public class GameUIManager : MonoBehaviour
{
    [Header("UI 요소")]
    [SerializeField] private GameObject settingsPopup; // 설정 팝업 패널

    void Start()
    {
        // 시작 시 팝업은 비활성화, 게임 시간은 정상 속도로 설정
        if (settingsPopup != null)
        {
            settingsPopup.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    /// <summary>
    /// [버튼 연결용] 모든 버튼의 클릭 이벤트를 처리하는 공용 메서드.
    /// Unity Editor에서 버튼의 OnClick() 이벤트에 이 메서드를 연결하고,
    /// 인자로 ButtonRole 열거형 값을 지정합니다.
    /// </summary>
    /// <param name="role">버튼의 역할</param>
    public void OnButtonClick(ButtonRole role)
    {
        switch (role)
        {
            case ButtonRole.Restart:
                HandleRestartGame();
                break;
            case ButtonRole.Lobby:
                HandleGoToLobby();
                break;
            case ButtonRole.ToggleSettings:
                HandleToggleSettingsPopup();
                break;
            case ButtonRole.TemporaryStop: 
                HandleTemporaryStop();
                break;
            case ButtonRole.Reset:
                ResetBestScore();
                break;
            default:
                Debug.LogWarning($"Unknown button role: {role}");
                break;
        }
    }

    /// <summary>
    /// 설정 팝업을 켜거나 끕니다. 팝업 활성화 시 시간을 멈춥니다.
    /// </summary>
    public void HandleToggleSettingsPopup()
    {
        SettingPopupUi.Instance.ShowSetting();
    }

    /// <summary>
    /// 현재 씬을 다시 로드하여 게임을 재시작합니다.
    /// </summary>
    public void HandleRestartGame()
    {
        Time.timeScale = 1f; // 시간 정지 해제
        LoadScene(GameScene.MainScene);
    }

    /// <summary>
    /// 게임을 일시 정지(시간을 멈춤)합니다.
    /// </summary>
    public void HandleTemporaryStop()
    {
        if (ResultPopupUI.Instance.isResultShown == true) return;
        if (settingsPopup == null) return;

        bool isActive = !settingsPopup.activeSelf;
        settingsPopup.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
    }

    /// <summary>
    /// 로비 씬으로 이동합니다.
    /// </summary>
    public void HandleGoToLobby()
    {
        Time.timeScale = 1f; // 시간 정지 해제
        LoadScene(GameScene.LobyScene);
    }

    public void ResetBestScore()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        ScoreManager.Instance.BestScore = PlayerPrefs.GetInt("BestScore", 0);
        Debug.Log("최고점수는 " + ScoreManager.Instance.BestScore + "입니다!");
    }
}
