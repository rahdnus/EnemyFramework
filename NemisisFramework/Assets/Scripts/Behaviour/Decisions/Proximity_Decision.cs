using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Proximity_Decision : Decision
{
    [SerializeField]float mindistance=30f;
   
  public override bool decide(StateController controller)
  {
      if(Mathf.Abs((controller.Target.position-controller.transform.position).magnitude)>mindistance )
      {
          return true;
      }
      return false;
  }
  
  
}
