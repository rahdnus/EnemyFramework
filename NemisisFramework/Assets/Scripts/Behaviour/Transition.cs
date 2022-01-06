using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition :ScriptableObject
{
[HideInInspector]public Vector2 position;
  [HideInInspector] public string guid;
   public Decision decision;
    public Traversable truetrav;
    public Traversable falsetrav;

    public bool TakeDecision(StateController controller)
    {
        return decision.decide(controller);
    }
}
