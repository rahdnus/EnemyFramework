using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class CombatAction : Action
{
    public string animationname;   
    public int energycost=20;
    public int animationlayer=0;
    public float transitiontime=0.3f;
        float attacktime;
    

   float counter;
    
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        
        controller.anim.applyRootMotion=true;
       
        if(controller.agent)
            controller.agent.isStopped=true;
        controller.flagHandler.isattacking=true;
        attacktime=controller.anim.GetCurrentAnimatorStateInfo(0).length;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime);

        
            // Debug.Log("Depleting");
    }
    public override void Act(StateController controller)
    {
            if(counter<attacktime)
      {
          counter+=Time.deltaTime;
      }
      
          

    }
     public override void FixedAct(StateController controller)
    {
    }
    public override void onExit(StateController controller)
    {
       
                if(controller.agent)
        controller.agent.isStopped=false;
        controller.anim.applyRootMotion=false;

        
    }

}
