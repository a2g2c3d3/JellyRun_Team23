using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollowPlayer : MonoBehaviour
{
    public Transform target;
    private void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 followPos = target.position + new Vector3(-0.5f,0,0); //³»°Ô·Î ´Ù°¡¿Í »ìÂ¦Äô
            transform.position = Vector3.Lerp(transform.position, followPos, Time.deltaTime * 5f);
            
        }
    }
}
