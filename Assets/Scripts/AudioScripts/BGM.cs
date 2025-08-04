using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    public Slider bgmSlider;             // BGM �����̴�
    public AudioSource audioSource;

    string nowSceneName;            //�� �̸��� ���� Ŭ�� �ٿ��ٰ͵� �̸� �޾Ƶα�
    public AudioClip titleClip;
    public AudioClip lobyClip;
    public AudioClip mainClip;
    public AudioClip shopClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    void Start()
    {
        // ����� �� �ҷ����� (�⺻�� 1)
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        // �����̴� �̺�Ʈ ����
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void Update()
    {
        if (nowSceneName != SceneManager.GetActiveScene().name)
        {
            nowSceneName = SceneManager.GetActiveScene().name; // �� �̸� ��������

            if (nowSceneName == "Title Scene")
            {
                Stop();
                Play(titleClip);
            }
            else if (nowSceneName == "LobyScene")
            {
                Stop();
                Play(lobyClip);
            }
            else if (nowSceneName == "MainScene")
            {
                Stop();
                Play(mainClip);
            }
            else if (nowSceneName == "ShopScene")
            {
                Stop();
                Play(shopClip);
            }
        }
    }

    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume); // ����
    }

    public void Play(AudioClip clip)
    {
        if (audioSource.clip != clip)
        {
            audioSource.clip = clip;
            audioSource.ignoreListenerPause = true;
            audioSource.Play();
        }
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
