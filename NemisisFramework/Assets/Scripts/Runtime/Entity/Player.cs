using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    Rigidbody rb;
    CameraInputHandler cameraInputHandler;
    // [SerializeField]SFXnParticles gunparticles;
    // [SerializeField]AudioSource source;
    // float range=30;
    //temp
    // public SFX_Particle_Manager manager;
    protected override void Start()
    {
        base.Start();
        rb=GetComponent<Rigidbody>();
        cameraInputHandler=GetComponent<CameraInputHandler>();
    }
    public override Vector3 getposition()
    {
        float run_multiplier;
        float horizontal=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
             run_multiplier=1.35f;
        }
        else
        {
            run_multiplier=1f;
        }
        Vector3 move=new Vector3(horizontal,0,vertical).normalized;
        return move*run_multiplier;
    }
    public override void Move(Vector3 position)
    {

        rb.velocity=((transform.right*position.x+transform.forward*position.z)*movementSpeed)+transform.up*Physics.gravity.y;

        // Debug.Log(position*movementSpeed);
        transform.rotation=Quaternion.Euler(new Vector3(transform.rotation.x,cameraInputHandler.target.eulerAngles.y,transform.rotation.z));
    }
    public override void Attack()
    {
        weapon.Attack();
    }
    IEnumerator delayshot(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.05f);
        // manager.Play( hit.collider.gameObject.layer,hit.point,Quaternion.LookRotation(hit.normal,Vector3.up));
       

    }

   

}
