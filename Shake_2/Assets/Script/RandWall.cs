using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandWall : MonoBehaviour
{
    public float timeout = 10;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeout);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
