using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX : MonoBehaviour
{
    public Slider sfxSlider;             // BGM �����̴�
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // ����� �� �ҷ����� (�⺻�� 1)
        float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = savedVolume;
        audioSource.volume = savedVolume;

        // �����̴� �̺�Ʈ ����
        sfxSlider.onValueChanged.AddListener(SetBGMVolume);
    }

    public void SetBGMVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume); // ����
    }

    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}