
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TransitionView : Node
{
    
    public Transition transition;
    public Port D_input;
    public Port ST_input,SF_input;
    public Port output;
    public TransitionView(Transition transition)
    {
        this.transition=transition;
        this.title="Transition";
        this.elementTypeColor=Color.blue;
        viewDataKey=transition.guid;
        style.left=transition.position.x;
        style.top=transition.position.y;
        CreateInputPorts();
        CreateOutputPorts();
    }
      private void CreateInputPorts()
   {
        D_input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
        D_input.portName="Decision";
        ST_input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        ST_input.portName="True";
        SF_input = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Single, typeof(bool));
        SF_input.portName="False";
        
        inputContainer.Add(D_input);
        inputContainer.Add(ST_input);
        inputContainer.Add(SF_input);
    }
     private void CreateOutputPorts()
   {
        output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
        outputContainer.Add(output);
    }
    public override void SetPosition(Rect newPos)
    {
        base.SetPosition(newPos);
        transition.position.x=newPos.xMin;
        transition.position.y=newPos.yMin;
    }
}
