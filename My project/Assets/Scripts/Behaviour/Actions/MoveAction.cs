using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
 
    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f;

    [SerializeField] float Speed=4;
    public override void onEnter(StateController controller)
    {
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        controller.agent.speed=Speed;
        controller.agent.updateRotation=false;
        controller.agent.destination=controller.backjump.position;
    }
    public override void Act(StateController controller)
    {
        
    }
    public override void onExit(StateController controller)
    {
        controller.agent.updateRotation=true;
    }
}
