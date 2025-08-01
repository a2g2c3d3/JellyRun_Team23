using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowPlayer : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        if(target != null)
        {
            Vector3 followPos = target.position + new Vector3(-1.5f,0,0); //³»°Ô·Î ´Ù°¡¿Í »ìÂ¦Äô
            transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime * 5f);
        }
    }
}
