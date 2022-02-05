using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    public Transform target;
    public Transform waypoint;
    public int nextwaypoint;
    public NavMeshAgent agent;
    protected override void Start()
    {
        base.Start();
        agent=GetComponent<NavMeshAgent>();
    }
    public override Vector3 getposition()
    {
        return target.position;
    }
    public override void Move(Vector3 position)
    {
        agent.SetDestination(position);
    }
    public override void preAttack()
    {
        agent.isStopped=true;
    }
    public override void postAttack()
    {
        agent.isStopped=false;
    }
}
