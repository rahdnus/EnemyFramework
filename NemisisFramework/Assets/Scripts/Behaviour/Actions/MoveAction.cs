using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : Action
{
    Enemy me;
    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f;

    [SerializeField] float Speed=4;
    public override void onEnter(StateController controller)
    {
        me=controller.entity as Enemy;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        me.agent.speed=Speed;
        me.agent.updateRotation=false;
        me.agent.destination=controller.backjump.position;
    }
    public override void Act(StateController controller)
    {
        
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
        me.agent.updateRotation=true;
    }
}
