using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public void SelectCharacter(string characterName)
    {
        PlayerPrefs.SetString("SelectedCharacter", characterName);
        PlayerPrefs.Save();
        Debug.Log($"SelectedCharacter: {characterName}");
    }
}
