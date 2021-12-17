using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
       
        if(!controller.agent.pathPending && controller.agent.remainingDistance<0.1f || !controller.agent.hasPath)
        {
            controller.agent.SetDestination(controller.waypoints[controller.nextwaypoint].position);
            Debug.Log("set destination");
            controller.nextwaypoint=(controller.nextwaypoint+1)%controller.waypoints.Count;
        }
    }
}
