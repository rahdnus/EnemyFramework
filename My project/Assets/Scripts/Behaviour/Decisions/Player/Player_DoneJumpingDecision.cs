using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DoneJumping : Decision
{
    public override bool decide(StateController controller)
    {
        if(controller.GetComponent<Player>().donejumping)
            return true;
        
        return false;
    }
}
