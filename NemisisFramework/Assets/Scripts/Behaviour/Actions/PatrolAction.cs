using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    Enemy me;
    public float movementSpeed;
    List<Vector3> waypoints;
    public override void onEnter(StateController controller)
    {
        controller.GetComponent<Animator>().CrossFadeInFixedTime("Patrol",0.3f);
        me=controller.entity as Enemy;
        me.movementSpeed=movementSpeed;
        me.nextwaypoint=0;
        foreach(Transform child in me.waypoint)
            waypoints.Add(child.position);
        
    }
    public override void Act(StateController controller)
    {
       
        if(!me.agent.pathPending && me.agent.remainingDistance<0.1f || !me.agent.hasPath)
        {
            me.agent.SetDestination(waypoints[me.nextwaypoint]);
            me.nextwaypoint=(me.nextwaypoint+1)%waypoints.Count;
        }
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
    }
}
