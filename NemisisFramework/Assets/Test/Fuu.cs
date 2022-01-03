using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuu : MonoBehaviour
{
    public bool root;
    void Update()
    {
        GetComponent<Animator>().applyRootMotion=root;

    }

    
}
