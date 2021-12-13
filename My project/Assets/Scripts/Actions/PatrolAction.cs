using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Action/Patrol")]
public class PatrolAction : Action
{
    public override void Act(StateController controller)
    {
        if(!controller.agent.pathPending && controller.agent.remainingDistance<0.1f || !controller.agent.hasPath)
        {
            controller.agent.SetDestination(controller.waypoints[controller.nextwaypoint].position);
            controller.nextwaypoint=(controller.nextwaypoint+1)%controller.waypoints.Count;
        }
    }
}
