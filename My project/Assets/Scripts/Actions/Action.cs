using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Action : ScriptableObject
{
   public Vector2 position;
   public string guid;
   public abstract void Act(StateController controller);
}
