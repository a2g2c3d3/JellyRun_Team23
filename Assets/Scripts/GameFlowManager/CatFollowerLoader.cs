using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowerLoader : MonoBehaviour
{
    public Transform playertransform;

    private void Start()
    {
        string selectedCat = PlayerPrefs.GetString("SelectedCharacter","");

        if (!string.IsNullOrEmpty(selectedCat))
            {
            GameObject catPrefab = Resources.Load<GameObject>($"Followers/{selectedCat}");

            if(catPrefab != null)
            {
                GameObject cat = Instantiate(catPrefab, playertransform.position + new Vector3(1f,0,0), Quaternion.identity);
                //cat.AddComponent<cat>().target = playertransform;
            }
        }
    }
}
