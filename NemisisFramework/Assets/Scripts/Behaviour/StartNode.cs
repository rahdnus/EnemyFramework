using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNode : Traversable
{
  public Traversable first;
  public override void onEnter(StateController controller)
  {
     
      if (first.GetType() == typeof(StateLeaf))
      {
         Debug.Log("going to start leaf");
        controller.changeCurrnetTree(first as StateTree);
      }
      else if (first.GetType() == typeof(State))
      {
        Debug.Log("in start of state");
        var leaf = controller.tree as StateLeaf;
         
        leaf.changeCurrentState(first as State,controller);
      }
  }
  
}
