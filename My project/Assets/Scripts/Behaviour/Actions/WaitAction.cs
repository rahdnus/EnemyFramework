using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : Action
{
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        controller.agent.isStopped=true;
        controller.GetComponent<Animator>().CrossFadeInFixedTime("Idle",1f);
    }
    public override void Act(StateController controller)
    {
        
    }
    public override void onExit(StateController controller)
    {
       controller.agent.isStopped=false;
    }

}