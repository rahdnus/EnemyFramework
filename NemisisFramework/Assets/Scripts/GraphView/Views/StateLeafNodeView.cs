
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class StateLeafNodeView : NodeView
{
    public System.Action<NodeView> onTreeSelected;
        public StateLeaf leaf;
    public Port output;
    public override void OnSelected()
    {
        base.OnSelected();
       onTreeSelected(this);
    }
    public StateLeafNodeView(StateLeaf newleaf)
    {
        this.leaf=newleaf;
       this.title=newleaf.name;
        viewDataKey=newleaf.guid;
        style.left=newleaf.position.x;
        style.top=newleaf.position.y;
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
        leaf.position.x=newPos.xMin;
        leaf.position.y=newPos.yMin;
    }
}

