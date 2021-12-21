using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    [SerializeField] StateTree tree;
   public State currentstate;
   public State remaininstate;
   public LayerMask targetlayer;
   public Transform Target;
   [HideInInspector]public NavMeshAgent agent;
   public List<Transform> waypoints;
  public int nextwaypoint=0;
   void Awake()
   {
       currentstate=tree.states[0];
       agent=GetComponent<NavMeshAgent>();
   }
    void Update()
    {
    currentstate.UpdateState(this);
    }
    public void ChangetoState(State newstate)
    {
        //find solution for this ***
        if(newstate!=null)
        {
            currentstate=newstate;
            currentstate.onEnter(this);

        }
    }
}
