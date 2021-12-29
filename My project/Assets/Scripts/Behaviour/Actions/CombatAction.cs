using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatAction : Action
{
    public string animationname;   
    public int energycost=20;
    public int animationlayer=0;
    public float transitiontime=0.3f;
   
    
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        if(controller.agent.enabled==true)
            controller.agent.isStopped=true;
        controller.isattacking=true;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime);
            // animationflag=false;
            // Debug.Log("Depleting");
    }
    public override void Act(StateController controller)
    {
        
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
        if(controller.agent.enabled==true)
            controller.agent.isStopped=false;
    }

}
