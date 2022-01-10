using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteDecision : Decision
{
    public bool absolutebool;
    public override bool decide(StateController controller)
    {
        return absolutebool;
    }
}

