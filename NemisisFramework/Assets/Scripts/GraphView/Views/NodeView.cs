
using UnityEngine.UIElements;

public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public System.Action<NodeView> onNodeSelected;
    public override void OnSelected()
    {     
        if(onNodeSelected!=null)
        {
           onNodeSelected(this);
        }
    }
  
}
