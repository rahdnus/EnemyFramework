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
//        controller.anim.CrossFadeInFixedTime("Jump",0.3f);
        controller.foot.gameObject.SetActive(false);

       jumptime=controller.anim.GetCurrentAnimatorStateInfo(0).length;
//        controller.agent.enabled=false;
        camerahandler=controller.GetComponent<CameraInputHandler>();
        //controller.anim.applyRootMotion=true;
    }
    public override void Act(StateController controller)
    {
      if(counter<jumptime)
      {
          counter+=Time.deltaTime;
      }
      if(counter>=jumptime)
      {
          controller.foot.gameObject.SetActive(true);
      }
    }
    public override void FixedAct(StateController controller)
    {
        controller.rb.velocity=new Vector3(0f,jumpcurve.Evaluate(counter/jumptime)*movementSpeed,0)+controller.transform.forward*movementSpeed;
    }
    public override void onExit(StateController controller)
    {
        counter=0;
        controller.foot.gameObject.SetActive(false);

    }
}