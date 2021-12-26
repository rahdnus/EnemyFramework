using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatAction : Action
{
    public string animationname;   
    public int energycost=20;
    public int animationlayer=0;
    public float transitiontime=0.3f;
    bool animationflag=true; 
    float counter=0;
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        controller.agent.isStopped=true;
        controller.isattacking=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime-0.001f);
            // animationflag=false;
            // Debug.Log("Depleting");
    }
    public override void Act(StateController controller)
    {
        
    }
    public override void onExit(StateController controller)
    {
       controller.agent.isStopped=false;
    }

}
