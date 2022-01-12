using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traversable : ScriptableObject
{
    [HideInInspector]public Vector2 position;
    [HideInInspector] public string guid;
   
     public virtual void onEnter(StateController controller)
    {
        
    }
    public virtual void update(StateController controller)
    {
       
    }
    public virtual void fixedUpdate(StateController controller)
    {
       
    }
    public virtual void DoTranisiton(StateController controller)
    {
        // for(int i=0;i<mytransitions.Count;i++)
        // {
        // //     if(mytransitions[i].TakeDecision(controller))
        // //     {
        // //         controller.changeCurrnetTree(mytransitions[i].truestate);
        // //     }
        // //     else
        // //     {
        // //         controller.changeCurrnetTree(mytransitions[i].falsestate);
        // //     }
        // }
    }
    
    public virtual void onExit(StateController controller)
    {

    }
}
