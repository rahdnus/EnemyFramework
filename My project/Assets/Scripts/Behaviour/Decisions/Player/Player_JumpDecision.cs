using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_JumpDecision : Decision
{
    public override bool decide(StateController controller)
    {
        if(Input.GetKeyDown(KeyCode.Space))
            return true;
        
        return false;
    }
}