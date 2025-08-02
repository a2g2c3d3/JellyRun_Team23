using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowerLoader : MonoBehaviour
{
    public Transform playertransform;
    public List<GameObject> petPrefabs; // �� ������ ����Ʈ

    private void Start()
    {

        string selectedCat = PlayerPrefs.GetString("SelectedCharacter");

        if (!string.IsNullOrEmpty(selectedCat))
            {
            GameObject catPrefab = Resources.Load<GameObject>("Followers/" + selectedCat);

            if(catPrefab != null)
            {
                GameObject cat = Instantiate(catPrefab, playertransform.position + new Vector3(1f,0,0), Quaternion.identity);
                

            }
            else
            {
                Debug.Log("냥이 오브젝트를 확인해봐");
            }
        }
        else
        {
            Debug.Log("리소스를 불러오는데 문제가 있어");
        }
    }

}
