using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class StateView : UnityEditor.Experimental.GraphView.Node
{
    public State state;
   public StateView(State state)
   {
       this.state=state;
       this.title=state.name;
       viewDataKey=state.guid;
   }
}
