
public class NodeView : UnityEditor.Experimental.GraphView.Node
{
    public System.Action<NodeView> onNodeSelected;
    public override void OnSelected()
    {
        base.OnSelected();
        if(onNodeSelected!=null)
        {
           // onNodeSelected(this);
        }
    }
}
