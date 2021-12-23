using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeAttackAction : Action
{
    public override void onEnter(StateController controller)
    {
        if(controller.energy>60)
        {
            //defend
            controller.agent.isStopped=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime("Center_Block",0.1f);
        }
        else if(controller.energy>10)
        {
            controller.agent.updateRotation=false;
            controller.agent.destination=controller.backjump.position;
            controller.GetComponent<Animator>().CrossFadeInFixedTime("Back_Step",0.2f);

        }
        else
        {
            controller.agent.isStopped=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime("Got_Hit",1f);

        }
    }
    public override void Act(StateController controller)
    {
        return;
    }
    public override void onExit(StateController controller)
    {
        controller.agent.updateRotation=true;
        controller.agent.isStopped=false;
    }
}
