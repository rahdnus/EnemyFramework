using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="State",menuName ="PlugAI/State")]
public class State : ScriptableObject
{
    public string guid;
    public Action[] actions;
    public Transition[] transitions;

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
        for(int i=0;i<actions.Length;i++)
        {
            actions[i].Act(controller);
        }
    }
    public void DoTranisiton(StateController controller)
    {
        for(int i=0;i<transitions.Length;i++)
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
}
