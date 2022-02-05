using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndNode : Traversable
{
    public Traversable parent;

    public override void onEnter(StateController controller)
    {
      //  Debug.Log("Exit reached"+parent.name);
        if(parent!=null)
        {   if(parent.GetType()==typeof(EndNode))
                controller.changeCurrnetTree(parent);
            else
                controller.changeCurrnetTree(parent);
        }
    }
    public override void DoTranisiton(StateController controller)
    {
      //  Debug.Log("bruh stop");
    }
}
