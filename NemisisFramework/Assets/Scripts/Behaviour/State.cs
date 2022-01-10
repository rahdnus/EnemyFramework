using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="State",menuName ="PlugAI/State")]
public class State : Traversable
{
    public List<Action> actions=new List<Action>();

    public override void onEnter(StateController controller)
    {
        if(actions!=null)
        {
            actions.ForEach((action)=>action.onEnter(controller));
        }
    }
    public override void update(StateController controller)
    {
        if(actions!=null)
         DoAction(controller);
        if(mytransitions!=null)
        {
               Debug.Log(this.name);
         DoTranisiton(controller);
        }
     

    }
    public override void fixedUpdate(StateController controller)
    {
        if(actions!=null)
        {
            DoFixedAction(controller);
        }
    }
    public void DoFixedAction(StateController controller)
    {
         for(int i=0;i<actions.Count;i++)
        {
            actions[i].FixedAct(controller);
        }
    }
    public void DoAction(StateController controller)
    {
        for(int i=0;i<actions.Count;i++)
        {
            actions[i].Act(controller);
        }
    }
    public override void DoTranisiton(StateController controller)
    {
        for(int i=0;i<mytransitions.Count;i++)
        {
            StateLeaf leaf=controller.tree as StateLeaf;
            if(mytransitions[i].TakeDecision(controller))
            {
                Debug.Log("yo"+mytransitions[i].truetrav.name);
                leaf.changeCurrentState(mytransitions[i].truetrav as State,controller);
            }
            else
            {
                leaf.changeCurrentState(mytransitions[i].falsetrav as State,controller);
            }
        }
    }
    
    public override void onExit(StateController controller)
    {
        if(actions!=null)
        {
            actions.ForEach((action)=>action.onExit(controller));
        }
    }
}
