using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;
    
    bool status = false;
    public void SelectCharacter(string characterName)
    {
        audioSource.Play();
        if (!status)
        {
            PlayerPrefs.SetString("SelectedCharacter", characterName);
            PlayerPrefs.Save();
            Debug.Log($"SelectedCharacter: {characterName}");
            animator.SetTrigger("CatClickTriggerTrue");
            status = true;
        }
        else
        {
            PlayerPrefs.SetString("SelectedCharacter", null);
            PlayerPrefs.Save();
            Debug.Log($"SelectedCharacter: {null}");
            animator.SetTrigger("CatClickTriggerFalse");
            status = false;
        }
    }
}

