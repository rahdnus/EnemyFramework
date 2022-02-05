using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Entity))]
public class StateController : MonoBehaviour
{
    [HideInInspector]public FlagHandler flagHandler;
    public int maxenergy=100;
    public int energy=100;//temporary;will be substituted by entity stats 
    public Transform backjump;
    public Traversable tree;
   [HideInInspector]public Entity entity;
   [HideInInspector]public Animator anim;

   void Awake()
   {
      // currentstate=tree.states[0];
       flagHandler=GetComponent<FlagHandler>();
       entity=GetComponent<Entity>();
       anim=GetComponent<Animator>();
       tree.onEnter(this);
   }
    void Update()
    {
    tree.update(this);
    }
    void FixedUpdate()
    {
    tree.fixedUpdate(this);
    }
  
    public void changeCurrnetTree(Traversable newtree)
    {
        // //find solution for this ***
        // if(newstate!=null)
        // {
        //     Debug.Log(newstate.name);
        //     currenttraversable.onExit(this);
        //     currenttraversable=newstate;
        //     currenttraversable.onEnter(this);
        // }
       
        if(newtree!=null)
        {
           //  Debug.Log(newtree.name);
            tree.onExit(this);
            tree=newtree;
           // Debug.Log(tree.name);
            tree.onEnter(this);
        }
    }

    public void Block()
    {
        Debug.Log("blocked");
    }
   
}
