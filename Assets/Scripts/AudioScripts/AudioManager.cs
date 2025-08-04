using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public SFX sfx;
    public BGM bgm;

    [Header("ȿ���� Ŭ����")]
    public AudioClip jumpClip;
    public AudioClip slideClip;
    public AudioClip scoreClip;
    public AudioClip hpClip;
    public AudioClip boosterClip;
    public AudioClip crushClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� ����
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

    public void ScoreSound()
    {
        sfx.PlayOneShot(scoreClip);
    }

    public void HpSound()
    {
        sfx.PlayOneShot(hpClip);
    }

    public void BoosterSound()
    {
        sfx.PlayOneShot(boosterClip);
    }

    public void CrushSound()
    {
        sfx.PlayOneShot(crushClip);
    }

}
