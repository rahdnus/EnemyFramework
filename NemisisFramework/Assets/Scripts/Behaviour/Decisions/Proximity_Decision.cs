using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Proximity_Decision : Decision
{
    [SerializeField]float mindistance=30f;
   Enemy enemy;
  public override bool decide(StateController controller)
  {
      enemy=controller.entity as Enemy;
      if(Mathf.Abs((enemy.target.position-controller.transform.position).magnitude)>mindistance)
      {
          return true;
      }
      return false;
  }
  
  
}
