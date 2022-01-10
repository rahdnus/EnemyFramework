using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndNode : State
{
    public Traversable parent;

    public override void onEnter(StateController controller)
    {
        Debug.Log("Exit reached"+parent.name);
        if(parent!=null)
        {   
            if(parent.GetType()==typeof(StateBranch))
            {
                StateBranch branch=parent as StateBranch;
                branch.hasbeentravelled=true;
            }
            controller.changeCurrnetTree(parent as StateTree);
        }
    }
    public override void DoTranisiton(StateController controller)
    {
        Debug.Log("bruh stop");
    }
}
