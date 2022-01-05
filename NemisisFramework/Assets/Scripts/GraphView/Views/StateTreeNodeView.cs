
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StateTreeNodeView : NodeView
{
    public System.Action<NodeView> onTreeSelected;
        public StateBranch branch;
    public Port output;
    public override void OnSelected()
    {
        base.OnSelected();
        onTreeSelected(this);
    }
    public StateTreeNodeView(StateBranch newbranch)
    {
        this.branch=newbranch;
        this.title=newbranch.name;
        viewDataKey=newbranch.guid;
        style.left=newbranch.position.x;
        style.top=newbranch.position.y;
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
        branch.position.x=newPos.xMin;
        branch.position.y=newPos.yMin;
    }
}
