using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndNode : Traversable
{
    public Traversable parent;

    public override void onEnter(StateController controller)
    {
        controller.changeCurrnetTree(parent as StateTree);
    }
}
