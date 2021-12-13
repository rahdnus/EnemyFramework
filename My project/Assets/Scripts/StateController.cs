using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
   public State currentstate;
   public State remaininstate;
   public LayerMask targetlayer;
   public Transform Target;
   [HideInInspector]public NavMeshAgent agent;
   public List<Transform> waypoints;
  public int nextwaypoint=0;
   void Awake()
   {
       agent=GetComponent<NavMeshAgent>();
   }
    void Update()
    {
        currentstate.UpdateState(this);
    }
    public void ChangetoState(State newstate)
    {
        if(newstate!=remaininstate)
        {
            currentstate=newstate;

        }
    }
}
