using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatAction : Action
{
    public Attack attacks;
                
    public override void onEnter(StateController controller)
    {
        
    }

    public override void Act(StateController controller)
    {
  
     attacks.attack(controller);
    }

}
