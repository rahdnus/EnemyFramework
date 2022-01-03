using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MoveAction : Action
{
    [SerializeField] float movementSpeed=5;
    float horizontal,vertical;
    float run_multiplier;
    CameraInputHandler camerahandler;
    public override void onEnter(StateController controller)
    {
        controller.anim.CrossFadeInFixedTime("Move",0.3f);
//        controller.agent.enabled=false;
        camerahandler=controller.GetComponent<CameraInputHandler>();
        run_multiplier=0.5f;
    }
    public override void Act(StateController controller)
    {
       horizontal=Input.GetAxis("Horizontal");
        vertical=Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.LeftShift))
        {
         run_multiplier=2;
        }
         else
         {
             run_multiplier=1f;
         }
       controller.anim.SetFloat("VelX",horizontal*run_multiplier/2);
       controller.anim.SetFloat("VelY",vertical*run_multiplier/2);

    }
    public override void FixedAct(StateController controller)
    {if(horizontal!=0 || vertical!=0)
       {
           controller.transform.rotation=Quaternion.Euler(new Vector3(controller.transform.rotation.x,camerahandler.target.eulerAngles.y,controller.transform.rotation.z));
          //  camerahandler.target.rotation=Quaternion.Euler(new Vector3(camerahandler.rotation.x,0,0));
       }
        controller.rb.velocity=(controller.transform.right*horizontal+controller.transform.forward*vertical)*movementSpeed*run_multiplier;

    }
    public override void onExit(StateController controller)
    {
    }
}
