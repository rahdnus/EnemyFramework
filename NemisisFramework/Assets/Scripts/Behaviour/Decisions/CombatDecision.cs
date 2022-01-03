using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDecision : Decision
{
    public override bool decide(StateController controller)
    {
        return controller.flagHandler.isattacking;
    }
}
