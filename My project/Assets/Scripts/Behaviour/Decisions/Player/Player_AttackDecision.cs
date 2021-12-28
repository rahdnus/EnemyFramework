using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AttackDecision : Decision
{
    public override bool decide(StateController controller)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            return true;
        
        return false;
    }
}

