using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_DoneJumpingDecision : Decision
{
    [SerializeField] LayerMask GroundLayer;
    public override bool decide(StateController controller)
    {
        if(controller.foot.gameObject.activeSelf && Physics.Raycast(controller.foot.transform.position,-controller.transform.up,0.2f,GroundLayer))
            return true;
        
        return false;
    }
}
