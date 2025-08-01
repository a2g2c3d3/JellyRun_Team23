using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    bool status = false;
    public void SelectCharacter(string characterName)
    {

        if (!status)
        {
            PlayerPrefs.SetString("SelectedCharacter", characterName);
            PlayerPrefs.Save();
            Debug.Log($"SelectedCharacter: {characterName}");
            status = true;
        }
        else
        {
            PlayerPrefs.SetString("SelectedCharacter", null);
            PlayerPrefs.Save();
            Debug.Log($"SelectedCharacter: {null}");
            status = false;



        }
    }
}

