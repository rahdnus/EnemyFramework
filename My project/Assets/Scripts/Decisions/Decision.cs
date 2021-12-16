using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : ScriptableObject
{
   public Vector2 position;
   public string guid;
   public abstract bool decide(StateController controller);
}
