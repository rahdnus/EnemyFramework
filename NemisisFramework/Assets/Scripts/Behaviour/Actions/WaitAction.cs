using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : Action
{
    Enemy me;
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        me=controller.entity as Enemy;
        me.agent.isStopped=true;
        controller.GetComponent<Animator>().CrossFadeInFixedTime("Idle",1f);
    }
    public override void Act(StateController controller)
    {
        
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
      me.agent.isStopped=false;
    }

}