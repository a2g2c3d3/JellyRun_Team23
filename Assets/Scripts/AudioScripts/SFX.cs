using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public Slider sfxSlider;             // BGM 슬라이더
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // 저장된 값 불러오기 (기본값 1)
        float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        // 슬라이더 이벤트 연결
        sfxSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume); // 저장
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}