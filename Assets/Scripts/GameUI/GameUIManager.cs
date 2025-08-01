using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum ButtonRole
{
    None, // ��ư ������ �������� ���� ����
    Restart, // ������ �ٽ� �����ϴ� ��ư
    Lobby, // �κ�� �̵��ϴ� ��ư
    ToggleSettings // ���� �˾��� �Ѱ� ���� ��ư
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
            default:
                Debug.LogWarning($"Unknown button role: {role}");
                break;
        }
    }

    /// <summary>
    /// ���� �˾��� �Ѱų� ���ϴ�. �˾� Ȱ��ȭ �� �ð��� ����ϴ�.
    /// </summary>
    private void HandleToggleSettingsPopup()
    {
        if (settingsPopup == null) return;

        bool isActive = !settingsPopup.activeSelf;
        settingsPopup.SetActive(isActive);

        Time.timeScale = isActive ? 0f : 1f;
    }

    /// <summary>
    /// ���� ���� �ٽ� �ε��Ͽ� ������ ������մϴ�.
    /// </summary>
    private void HandleRestartGame()
    {
        Time.timeScale = 1f; // �ð� ���� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// �κ� ������ �̵��մϴ�.
    /// </summary>
    private void HandleGoToLobby()
    {
        Time.timeScale = 1f; // �ð� ���� ����
        SceneManager.LoadScene("LobbyScene"); // "LobbyScene"�� ���� �κ� �� �̸����� �����ؾ� ��
    }
}
