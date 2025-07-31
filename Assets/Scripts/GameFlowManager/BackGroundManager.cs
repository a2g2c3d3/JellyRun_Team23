using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public Transform cloudtransform;
    public float cloudSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCloud();
    }
    void MoveCloud()
    {
        cloudtransform.Translate(Vector3.left * cloudSpeed * Time.deltaTime);
    }
}
