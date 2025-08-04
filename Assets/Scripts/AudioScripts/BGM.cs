using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    public Slider bgmSlider;             // BGM 슬라이더
    public AudioSource audioSource;

    string nowSceneName;            //씬 이름에 따라 클립 붙여줄것들 미리 받아두기
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
        // 저장된 값 불러오기 (기본값 1)
        float savedVolume = PlayerPrefs.GetFloat("BGMVolume", 1f);
        bgmSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        // 슬라이더 이벤트 연결
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    private void Update()
    {
        if (nowSceneName != SceneManager.GetActiveScene().name)
        {
            nowSceneName = SceneManager.GetActiveScene().name; // 씬 이름 가져오기

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
        PlayerPrefs.SetFloat("BGMVolume", volume); // 저장
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
