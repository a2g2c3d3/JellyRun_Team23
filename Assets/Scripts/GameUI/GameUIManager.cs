using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ButtonRole
{
    None, // 버튼 역할이 지정되지 않은 상태
    Restart, // 게임을 다시 시작하는 버튼
    Lobby, // 로비로 이동하는 버튼
    ToggleSettings // 설정 팝업을 켜고 끄는 버튼
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
            default:
                Debug.LogWarning($"Unknown button role: {role}");
                break;
        }
    }

    /// <summary>
    /// 설정 팝업을 켜거나 끕니다. 팝업 활성화 시 시간을 멈춥니다.
    /// </summary>
    private void HandleToggleSettingsPopup()
    {
        if (settingsPopup == null) return;

        bool isActive = !settingsPopup.activeSelf;
        settingsPopup.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
    }

    /// <summary>
    /// 현재 씬을 다시 로드하여 게임을 재시작합니다.
    /// </summary>
    private void HandleRestartGame()
    {
        Time.timeScale = 1f; // 시간 정지 해제
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 로비 씬으로 이동합니다.
    /// </summary>
    private void HandleGoToLobby()
    {
        Time.timeScale = 1f; // 시간 정지 해제
        SceneManager.LoadScene("LobbyScene"); // "LobbyScene"은 실제 로비 씬 이름으로 변경해야 함
    }
}
