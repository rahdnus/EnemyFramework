using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public bool isbeingattacked=false;
    public bool reacheddestination=false;
    public bool isattacking=false;
    public int maxenergy=100;
    public int energy=100;//temporary;will be substituted by entity stats 
    public Transform backjump;
    [SerializeField] StateTree tree;
   public State currentstate;
   public State remaininstate;
   public LayerMask targetlayer;
   public Transform Target;
   [HideInInspector] public Animator anim;
   [HideInInspector]public NavMeshAgent agent;
   [HideInInspector]public Rigidbody rb;
   [SerializeField] Transform hips;
   public List<Transform> waypoints;
  public int nextwaypoint=0;
   void Awake()
   {
       currentstate=tree.states[0];
       anim=GetComponentInChildren<Animator>();
       agent=GetComponent<NavMeshAgent>();
       rb=GetComponent<Rigidbody>();
       currentstate.onEnter(this);
   }
    void Update()
    {
    currentstate.UpdateState(this);
    }
    void FixedUpdate()
    {
        currentstate.DoFixedAction(this);
    }
    
    public void ChangetoState(State newstate)
    {
        //find solution for this ***
        if(newstate!=null)
        {
            Debug.Log(newstate.name);
            currentstate.onExit(this);
            currentstate=newstate;
            currentstate.onEnter(this);

        }
    }

    public void Block()
    {
        Debug.Log("blocked");
    }
    public void notBeingAttacked()
    {
        isbeingattacked=false;
    }
    public void DrainEnergy(int amount)
    {
        isattacking=false;
        energy-=amount;
    }
}
