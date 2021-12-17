using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="State",menuName ="PlugAI/State")]
public class State : ScriptableObject
{
    public Vector2 position;
    public string guid;
    public List<Action> actions;
    public List<Transition> transitions;

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
             Debug.Log("acting");
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
}
