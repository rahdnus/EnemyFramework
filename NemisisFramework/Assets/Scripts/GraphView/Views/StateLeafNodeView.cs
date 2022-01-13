
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class StateLeafNodeView : TreeGraphView
{
    public StateLeaf leaf;
    public Port output,input;
    public StateLeafNodeView(StateLeaf newleaf)
    {
        this.leaf=newleaf;
       this.title=newleaf.name;
        viewDataKey=newleaf.guid;
        style.left=newleaf.position.x;
        style.top=newleaf.position.y;
        CreateOutputPorts();
        CreateInputPorts();
    }   private void CreateOutputPorts()
   {
        output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        output.portName="this";
        outputContainer.Add(output);
    }
      private void CreateInputPorts()
   {
        input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
        input.portName="next";
        inputContainer.Add(input);
    }
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        leaf.position.x=newPos.xMin;
        leaf.position.y=newPos.yMin;
    }
}

