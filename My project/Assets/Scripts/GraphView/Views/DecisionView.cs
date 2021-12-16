
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class DecisionView : Node
{
    public Decision decision;
    public Port output;
    public DecisionView(Decision decision)
    {
        this.decision= decision;
        this.title= decision.name;
        viewDataKey= decision.guid;
        style.left= decision.position.x;
        style.top= decision.position.y;
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
        decision.position.x=newPos.xMin;
        decision.position.y=newPos.yMin;
    }
}
