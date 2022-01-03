using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fu : MonoBehaviour
{
    public Transform pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position=pos.position;
            pos.localPosition=Vector3.zero;

        }
    }
}
