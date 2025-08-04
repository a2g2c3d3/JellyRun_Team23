using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public SFX sfx;
    public BGM bgm;

    [Header("효과음 클립들")]
    public AudioClip jumpClip;
    public AudioClip slideClip;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void JumpSound()
    {
        sfx.PlayOneShot(jumpClip);
    }

    public void SlideSound()
    {
        sfx.PlayOneShot(slideClip);
    }

    public void PlayBGM(AudioClip clip)
    {
        bgm.Play(clip);
    }

    public void StopBGM()
    {
        bgm.Stop();
    }

}
