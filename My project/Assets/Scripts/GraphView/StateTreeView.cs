using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using System.Linq;
using System.Collections.Generic;

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
        evt.menu.AppendAction("ChaseAction",(b)=>createAction(typeof(ChaseAction)));
    }
    public void PopulateView(StateTree tree)
    {
        this.tree = tree;
        graphViewChanged -= GraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += GraphViewChanged;

        tree.states.ForEach(s => CreateStateView(s));
        tree.actions.ForEach(a=>CreateActionView(a));

        //-------------------------------------------------EDGE-POPULATE---------------------------------------------------------------//
       tree.states.ForEach(s=>
       {
           StateView stateView=GetNodeByGuid(s.guid)as StateView;
           s.actions.ForEach(a=>
           {
               ActionView actionView=GetNodeByGuid(a.guid) as ActionView;
               Edge edge=actionView.output.ConnectTo(stateView.A_input);
               AddElement(edge);
           });
       });
    
    }
    private GraphViewChange GraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.edgesToCreate!=null)
        {
            foreach(Edge edge in graphViewChange.edgesToCreate)
            {
        
                    Debug.Log("Edge Created");
                    if(edge.output.node.GetType()==typeof(ActionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        ActionView actionview=edge.output.node as ActionView;
                        Debug.Log("Action Added");
                        stateView.state.actions.Add(actionview.action);
                    }
            }
        }
        if(graphViewChange.elementsToRemove!=null)
        {
            foreach(GraphElement elem in graphViewChange.elementsToRemove)
            {
                if(elem.GetType()==typeof(StateView))
                {
                   StateView view=elem as StateView;
                    tree.RemoveState(view.state); 
                    
                }
                 if(elem.GetType()==typeof(ActionView))
                {
                   ActionView view=elem as ActionView;
                    tree.RemoveAction(view.action);
                }
                
                if(elem.GetType()==typeof(Edge))
                {
                    Edge edge=elem as Edge;
                    if(edge.output.node.GetType()==typeof(ActionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        ActionView actionview=edge.output.node as ActionView;
                        Debug.Log("Action Removed");
                        stateView.state.actions.Remove(actionview.action);
                    } 
                }
                
                
                    //remove referecne to tranition from state node
                
            }
        }
        
        return graphViewChange;
    }
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
       // return base.GetCompatiblePorts(startPort, nodeAdapter);
       return ports.ToList().Where(endport=>endport.direction!=startPort.direction).ToList();
    }
    void createState(System.Type type)
    {
        State state = tree.CreateState();
        CreateStateView(state);
    }
    void createAction(System.Type type)
    {
        Action action=tree.CreateAction(type);
        CreateActionView(action);
    }
    void CreateStateView(State state)
    {
        StateView stateview = new StateView(state);
        AddElement(stateview);
    }
    void CreateActionView(Action action)
    {
        ActionView actionview = new ActionView(action);
        AddElement(actionview);
    }
}
