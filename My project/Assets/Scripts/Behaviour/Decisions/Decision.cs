using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decision : ScriptableObject
{
   [HideInInspector]public Vector2 position;
   [HideInInspector]public string guid;
   public abstract bool decide(StateController controller);
}
