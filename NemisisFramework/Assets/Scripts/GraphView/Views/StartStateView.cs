
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class StartStateView : NodeView
{
    public StartNode start;
    public Port input;
   public StartStateView(StartNode state)
   {
       this.start=state;
       this.title=state.name;
       viewDataKey=state.guid;
       style.left=state.position.x;
       style.top=state.position.y;
       CreateInputPorts();
   }
 
    private void CreateInputPorts()
   {
        input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        input.portName="First State";
        inputContainer.Add(input);

    }
   public override void SetPosition(UnityEngine.Rect newPos)
   {
       base.SetPosition(newPos);
       start.position.x=newPos.xMin;
       start.position.y=newPos.yMin;
   }
}
