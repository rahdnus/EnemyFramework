
using UnityEditor.Experimental.GraphView;
public class StateView : Node
{
    public State state;
     public Port A_input;
    public Port T_input;
    public Port ouput;
   public StateView(State state)
   {
       this.state=state;
       this.title=state.name;
       viewDataKey=state.guid;
       style.left=state.position.x;
       style.top=state.position.y;
       CreateInputPorts();
       CreateOutputPorts();
   }
   private void CreateInputPorts()
   {
       A_input=InstantiatePort(Orientation.Horizontal,Direction.Input,Port.Capacity.Multi,typeof(bool));
       A_input.portName="Action";
       inputContainer.Add(A_input);
       T_input=InstantiatePort(Orientation.Horizontal,Direction.Input,Port.Capacity.Multi,typeof(bool));
       T_input.portName="Transition";
       inputContainer.Add(T_input);
   }
    private void CreateOutputPorts()
   {
        ouput = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
        ouput.portName="This State";
        outputContainer.Add(ouput);

    }
   public override void SetPosition(UnityEngine.Rect newPos)
   {
       base.SetPosition(newPos);
       state.position.x=newPos.xMin;
       state.position.y=newPos.yMin;
   }
}
