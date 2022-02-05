using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttackAction : Action
{
    Enemy me;
    public override void onEnter(StateController controller)
    {
        if(controller.energy>60)
        {
            //defend
            me.agent.isStopped=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime("Center_Block",0.1f);
        }
        else if(controller.energy>10)
        {
            me.agent.updateRotation=false;
            me.agent.destination=controller.backjump.position;
            controller.anim.CrossFadeInFixedTime("Back_Step",0.2f);

        }
        else
        {
            me.agent.isStopped=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime("Got_Hit",1f);

        }
    }
    public override void Act(StateController controller)
    {
        return;
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
        me.agent.updateRotation=true;
        me.agent.isStopped=false;
    }
}
