using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedDestinationDecision : Decision
{
   
  public override bool decide(StateController controller)
  {
      return controller.reacheddestination;
  }
  
  
}
