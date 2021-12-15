using System.Collections;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

public class StateTreeView : GraphView
{
    new public class UxmlFactory : UxmlFactory<StateTreeView, GraphView.UxmlTraits> { }
    StateTree tree;

    public StateTreeView()
    {
        Insert(0, new GridBackground());
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new ContentZoomer());
        this.AddManipulator(new RectangleSelector());
        this.AddManipulator(new SelectionDragger());
    }
    public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
    {
        evt.menu.AppendAction("State", (a) => createState(typeof(State)));
    }
    public void PopulateView(StateTree tree)
    {
        this.tree = tree;
        graphViewChanged -= GraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += GraphViewChanged;
        tree.states.ForEach(s => CreateStateView(s));
    }
    private GraphViewChange GraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.elementsToRemove!=null)
        {
            graphViewChange.elementsToRemove.ForEach((elem)=>{
                StateView view=elem as StateView;
                tree.RemoveState(view.state);
            });
        }
        return graphViewChange;
    }
    void createState(System.Type type)
    {
        State state = tree.CreateState();
        CreateStateView(state);
    }
    void CreateStateView(State state)
    {
        StateView stateview = new StateView(state);
        AddElement(stateview);
    }
}
