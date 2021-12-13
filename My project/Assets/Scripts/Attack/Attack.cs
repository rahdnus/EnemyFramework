using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack :ScriptableObject
{
  public abstract void attack(StateController controller);
}
