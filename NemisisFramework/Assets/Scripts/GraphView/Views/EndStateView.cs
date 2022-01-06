
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class EndStateView : NodeView
{
    public EndNode end;
    public Port input;
   public EndStateView(EndNode end)
   {
       this.end=end;
       this.title=end.name;
       viewDataKey=end.guid;
       style.left=end.position.x;
       style.top=end.position.y;
       CreateInputPorts();
   }
 
    private void CreateInputPorts()
   {
        input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(Traversable));
        input.portName="First State";
        inputContainer.Add(input);

    }
   public override void SetPosition(UnityEngine.Rect newPos)
   {
       base.SetPosition(newPos);
       end.position.x=newPos.xMin;
       end.position.y=newPos.yMin;
   }
}

