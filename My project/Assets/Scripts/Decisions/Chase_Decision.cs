using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Decision/Chase_D")]
public class Chase_Decision : Decision
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
