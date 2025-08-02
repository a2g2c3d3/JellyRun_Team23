using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameSceneManager;


/// <summary>
/// ���� �� ��ư�� ������ �����ϴ� ������.
/// ��ư�� ����� ��Ȯ�ϰ� �����ϰ� �߾� ����ȭ�ϴ� �� ���˴ϴ�.
/// </summary>
public enum ButtonRole
{
    None,
    Restart,
    Lobby,
    ToggleSettings,
    TemporaryStop
}

public class GameUIManager : MonoBehaviour
{
    [Header("UI ���")]
    [SerializeField] private GameObject settingsPopup; // ���� �˾� �г�

    void Start()
    {
        // ���� �� �˾��� ��Ȱ��ȭ, ���� �ð��� ���� �ӵ��� ����
        if (settingsPopup != null)
        {
            settingsPopup.SetActive(false);
        }
        Time.timeScale = 1f;
    }

    /// <summary>
    /// [��ư �����] ��� ��ư�� Ŭ�� �̺�Ʈ�� ó���ϴ� ���� �޼���.
    /// Unity Editor���� ��ư�� OnClick() �̺�Ʈ�� �� �޼��带 �����ϰ�,
    /// ���ڷ� ButtonRole ������ ���� �����մϴ�.
    /// </summary>
    /// <param name="role">��ư�� ����</param>
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
            default:
                Debug.LogWarning($"Unknown button role: {role}");
                break;
        }
    }

    /// <summary>
    /// ���� �˾��� �Ѱų� ���ϴ�. �˾� Ȱ��ȭ �� �ð��� ����ϴ�.
    /// </summary>
    public void HandleToggleSettingsPopup()
    {
        if (ResultPopupUI.Instance.isResultShown == true) return;
        if (settingsPopup == null) return;

        bool isActive = !settingsPopup.activeSelf;
        settingsPopup.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
        
    }

    /// <summary>
    /// ���� ���� �ٽ� �ε��Ͽ� ������ ������մϴ�.
    /// </summary>
    public void HandleRestartGame()
    {
        Time.timeScale = 1f; // �ð� ���� ����
        LoadScene(GameScene.MainScene);
    }

    /// <summary>
    /// ������ �Ͻ� ����(�ð��� ����)�մϴ�.
    /// </summary>
    public void HandleTemporaryStop()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0f;
            return;
        }
        Time.timeScale = 1f;
        // �ʿ��ϴٸ� ���⿡ �˾� UI�� Ȱ��ȭ�ϴ� �ڵ带 �߰��� �� �ֽ��ϴ�.
        // ��: if (pausePopup != null) pausePopup.SetActive(true);
    }

    /// <summary>
    /// �κ� ������ �̵��մϴ�.
    /// </summary>
    public void HandleGoToLobby()
    {
        Time.timeScale = 1f; // �ð� ���� ����
        LoadScene(GameScene.LobyScene);
    }
}
