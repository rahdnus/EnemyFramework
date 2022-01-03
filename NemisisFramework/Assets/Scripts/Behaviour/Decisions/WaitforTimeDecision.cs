using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitforTimeDecision : Decision
{
    [SerializeField] float waittime;
   float counter=0;
  public override bool decide(StateController controller)
  {
      counter+=Time.deltaTime;

     if(counter<waittime)
     {
         return false;
     }
     counter=0;
    return true;

     
  }
  
  
}

