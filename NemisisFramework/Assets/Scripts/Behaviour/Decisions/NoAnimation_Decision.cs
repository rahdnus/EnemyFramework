using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAnimation_Decision : Decision
{
    
   public int animationlayer=0;
   public string animationname;
  public override bool decide(StateController controller)
  {
      if(controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(animationlayer).IsName(animationname) 
      && controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(animationlayer).normalizedTime<1f)
      {
          Debug.Log("done");
          return true;
      }
      return false;
  }
  
  
}
