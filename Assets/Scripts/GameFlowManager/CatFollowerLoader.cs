using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowerLoader : MonoBehaviour
{
    public Transform playertransform;
    public List<GameObject> petPrefabs; // 펫 프리팹 리스트

    private void Start()
    {

        string selectedCat = PlayerPrefs.GetString("SelectedCharacter");

        if (!string.IsNullOrEmpty(selectedCat))
            {
            GameObject catPrefab = Resources.Load<GameObject>("Followers/" + selectedCat);

            if(catPrefab != null)
            {
                GameObject cat = Instantiate(catPrefab, playertransform.position + new Vector3(1f,0,0), Quaternion.identity);
                //cat.AddComponent<CatFollowPlayer>().target = playertransform;
            }
            else
            {
                Debug.Log("문제야 문제 이세상 속에");
            }
        }
        else
        {
            Debug.Log("똑같은 사랑 노래가");
        }
    }

}
