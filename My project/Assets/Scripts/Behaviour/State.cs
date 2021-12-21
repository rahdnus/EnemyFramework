using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="State",menuName ="PlugAI/State")]
public class State : ScriptableObject
{
[HideInInspector]public Vector2 position;
   [HideInInspector]public string guid;
    public List<Action> actions=new List<Action>();
    public List<Transition> transitions=new List<Transition>();

    public void onEnter(StateController controller)
    {
        if(actions!=null)
        {
            actions.ForEach((action)=>action.onEnter(controller));
        }
    }
    public void UpdateState(StateController controller)
    {
        if(actions!=null)
         DoAction(controller);
        if(transitions!=null)
        {
            DoTranisiton(controller);
        }

    }
    public void DoAction(StateController controller)
    {
        for(int i=0;i<actions.Count;i++)
        {
            actions[i].Act(controller);
        }
    }
    public void DoTranisiton(StateController controller)
    {
        for(int i=0;i<transitions.Count;i++)
        {
            if(transitions[i].TakeDecision(controller))
            {
                controller.ChangetoState(transitions[i].truestate);
            }
            else
            {
                controller.ChangetoState(transitions[i].falsestate);
            }
        }
    }
    
    public void onExit(StateController controller)
    {
        if(actions!=null)
        {
            actions.ForEach((action)=>action.onExit(controller));
        }
    }
}
