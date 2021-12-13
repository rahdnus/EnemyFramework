using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition 
{
   public Decision decision;
    public State truestate;
    public State falsestate;

    public bool TakeDecision(StateController controller)
    {
        return decision.decide(controller);
    }
}
