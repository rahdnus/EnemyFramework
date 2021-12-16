
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ActionView : Node
{
    public Action action;
    public Port output;
    public ActionView(Action action)
    {
        this.action=action;
        this.title=action.name;
        viewDataKey=action.guid;
        style.left=action.position.x;
        style.top=action.position.y;
        CreateOutputPorts();
    }
     private void CreateOutputPorts()
   {
        output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        outputContainer.Add(output);
    }
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        action.position.x=newPos.xMin;
        action.position.y=newPos.yMin;
    }
}
