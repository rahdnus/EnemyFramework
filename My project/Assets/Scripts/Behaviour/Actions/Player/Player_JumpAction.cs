using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpAction : Action
{
    [SerializeField]AnimationCurve jumpcurve=new AnimationCurve();
    [SerializeField] float movementSpeed=10f;
    [SerializeField] float jumptime=0.29f;
    float counter=0;
    float horizontal,vertical;
    
    CameraInputHandler camerahandler;
    public override void onEnter(StateController controller)
    {
        controller.anim.CrossFadeInFixedTime("Jump",0.3f);
       // jumptime=controller.anim.GetCurrentAnimatorStateInfo(0).length;
        controller.agent.enabled=false;
        camerahandler=controller.GetComponent<CameraInputHandler>();
        controller.anim.applyRootMotion=true;
    }
    public override void Act(StateController controller)
    {
      if(counter<jumptime)
      {
          counter+=Time.deltaTime;
      }
    }
    public override void FixedAct(StateController controller)
    {
        Debug.Log((counter/jumptime));
        controller.rb.velocity=new Vector3(0f,jumpcurve.Evaluate(counter/jumptime)*movementSpeed,0)+controller.transform.forward*movementSpeed;
    }
    public override void onExit(StateController controller)
    {
        controller.GetComponent<Player>().donejumping=false;
        counter=0;
        
    }
}