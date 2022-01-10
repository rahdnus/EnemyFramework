
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class EndStateView : NodeView
{
    public EndNode end;
    public Port output;
   public EndStateView(EndNode end)
   {
       this.end=end;
       this.title=end.name;
       viewDataKey=end.guid;
       style.left=end.position.x;
       style.top=end.position.y;
       CreateOutputPorts();
   }
 
    private void CreateOutputPorts()
   {
        output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(Traversable));
        output.portName="this";
        outputContainer.Add(output);

    }
   public override void SetPosition(UnityEngine.Rect newPos)
   {
       base.SetPosition(newPos);
       end.position.x=newPos.xMin;
       end.position.y=newPos.yMin;
   }
}

