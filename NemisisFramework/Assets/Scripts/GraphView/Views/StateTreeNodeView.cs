
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System.Collections;
using System;

public class StateTreeNodeView : NodeView
{
   
    public StateBranch branch;
    public Port output,input;
  
    public StateTreeNodeView(StateBranch newbranch)
    {
        this.branch=newbranch;
        this.title=newbranch.name;
        viewDataKey=newbranch.guid;
        style.left=newbranch.position.x;
        style.top=newbranch.position.y;
        CreateOutputPorts();
        CreateInputPorts();
    }
    public override void OnSelected()
    {
        // count+=1;
        // if(count==2)
        // {
        //     base.OnSelected();
        //     count=0;
        // }
        // else
        // {
         
        // }
    }
     private void CreateOutputPorts()
   {
        output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        output.portName="this";
        outputContainer.Add(output);
    }
      private void CreateInputPorts()
   {
        input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
        inputContainer.Add(input);
    }
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        branch.position.x=newPos.xMin;
        branch.position.y=newPos.yMin;
    }
}
