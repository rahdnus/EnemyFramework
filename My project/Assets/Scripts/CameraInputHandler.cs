using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInputHandler : MonoBehaviour
{
   [SerializeField] float sensitivity=1f;
   [HideInInspector]public Vector3 rotation=new Vector3();
   public Transform target;
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
        rotation=target.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    float horizontal=Input.GetAxis("Mouse X");
    float vertical=Input.GetAxis("Mouse Y");

    rotation+=new Vector3(-vertical,horizontal,0)*sensitivity;

    rotation.x=Mathf.Clamp(rotation.x,-30,30);
    

    }
    void FixedUpdate()
    {
        target.rotation=Quaternion.Euler(rotation);
    }
}
