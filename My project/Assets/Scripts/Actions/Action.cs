using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Action : ScriptableObject
{
   [HideInInspector]public Vector2 position;
  [HideInInspector] public string guid;
   public abstract void onEnter(StateController controller);
   public abstract void Act(StateController controller);
}
