using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    public override void onEnter(StateController controller)
    {
        controller.GetComponent<Animator>().CrossFadeInFixedTime("Walking",0.3f);
        controller.nextwaypoint=0;
    }
    public override void Act(StateController controller)
    {
       
        if(!controller.agent.pathPending && controller.agent.remainingDistance<0.1f || !controller.agent.hasPath)
        {
            controller.agent.SetDestination(controller.waypoints[controller.nextwaypoint].position);
            Debug.Log("set destination");
            controller.nextwaypoint=(controller.nextwaypoint+1)%controller.waypoints.Count;
        }
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
    }
}
