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
        evt.menu.AppendAction("Transition", (a) => createTranstion(typeof(Transition)));
        evt.menu.AppendAction("ChaseAction",(b)=>createAction(typeof(ChaseAction)));
        evt.menu.AppendAction("Chase_Decision",(d)=>createDecision(typeof(Chase_Decision)));
    }
    public void PopulateView(StateTree tree)
    {
        this.tree = tree;
        graphViewChanged -= GraphViewChanged;
        DeleteElements(graphElements);
        graphViewChanged += GraphViewChanged;

        tree.states.ForEach(s => CreateStateView(s));
        tree.actions.ForEach(a=>CreateActionView(a));
        tree.transitions.ForEach(t=>CreateTransitionView(t));
        tree.decisions.ForEach(d=>CreateDecisionView(d));

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

        tree.states.ForEach(s=>
       {
           StateView stateView=GetNodeByGuid(s.guid)as StateView;
           s.transitions.ForEach(a=>
           {
               TransitionView transitionView=GetNodeByGuid(a.guid) as TransitionView;
               Edge edge=transitionView.output.ConnectTo(stateView.T_input);
               AddElement(edge);
           });
       });

       tree.transitions.ForEach(t=>
       {
           TransitionView transitionView=GetNodeByGuid(t.guid) as TransitionView;
           var decision=transitionView.transition.decision;
           if(decision!=null)
           {
            DecisionView decisionView=GetNodeByGuid(decision.guid) as DecisionView;
            Debug.Log("decisin edge");
            Edge edge=decisionView.output.ConnectTo(transitionView.D_input);
            AddElement(edge);
           }
           
       });
       tree.transitions.ForEach(t=>
       {
            TransitionView transitionView=GetNodeByGuid(t.guid) as TransitionView;

            var truestate=transitionView.transition.truestate;
            if(truestate!=null)
            {
            StateView stateView=GetNodeByGuid(truestate.guid) as StateView;
            Edge edge=stateView.ouput.ConnectTo(transitionView.ST_input);
            AddElement(edge);
            }
            var falsestate=transitionView.transition.falsestate;
            if(falsestate!=null)
            {
            StateView stateView=GetNodeByGuid(falsestate.guid) as StateView;
            Edge edge=stateView.ouput.ConnectTo(transitionView.SF_input);
            AddElement(edge);
            }
            
       }
       );
    
    }
    private GraphViewChange GraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.edgesToCreate!=null)
        {
            foreach(Edge edge in graphViewChange.edgesToCreate)
            {
                    if(edge.output.node.GetType()==typeof(ActionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        ActionView actionview=edge.output.node as ActionView;
                        stateView.state.actions.Add(actionview.action);
                    }
                      if(edge.output.node.GetType()==typeof(TransitionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        TransitionView transitionview=edge.output.node as TransitionView;
                        stateView.state.transitions.Add(transitionview.transition);
                    }
                      if(edge.output.node.GetType()==typeof(DecisionView) && edge.input.node.GetType()==typeof(TransitionView))
                    {
                        DecisionView decisionView=edge.output.node as DecisionView;
                        TransitionView transitionview=edge.input.node as TransitionView;
                        transitionview.transition.decision=decisionView.decision;
                    }
                    if(edge.output.node.GetType()==typeof(StateView) && edge.input.node.GetType()==typeof(TransitionView))
                    {
                        StateView stateView=edge.output.node as StateView;
                        TransitionView transitionview=edge.input.node as TransitionView;

                        if(edge.input.portName=="True")
                            transitionview.transition.truestate=stateView.state;
                        else
                            transitionview.transition.falsestate=stateView.state;
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
                  if(elem.GetType()==typeof(TransitionView))
                {
                   TransitionView view=elem as TransitionView;
                    tree.RemoveTransition(view.transition);
                }
                  if(elem.GetType()==typeof(DecisionView))
                {
                   DecisionView view=elem as DecisionView;
                    tree.RemoveDecision(view.decision);
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
                     if(edge.output.node.GetType()==typeof(TransitionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        TransitionView transitionView=edge.output.node as TransitionView;
                        Debug.Log("Transition Removed");
                        stateView.state.transitions.Remove(transitionView.transition);
                    } 
                     if(edge.output.node.GetType()==typeof(DecisionView) && edge.input.node.GetType()==typeof(TransitionView))
                    {
                        DecisionView decisionView=edge.output.node as DecisionView;
                        TransitionView transitionView=edge.input.node as TransitionView;
                        Debug.Log("Decision Removed");
                        transitionView.transition.decision=null;
                    } 
                }
                
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
     void createTranstion(System.Type type)
    {
      Transition transition=tree.CreateTransition(type);
      CreateTransitionView(transition);
    }
    void createDecision(System.Type type)
    {
      Decision decision=tree.CreateDecision(type);
      CreateDecisionView(decision);
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
     void CreateTransitionView(Transition transition)
    {
        TransitionView transitionView= new TransitionView(transition);
        AddElement(transitionView);
    }
    void CreateDecisionView(Decision decision)
    {
       DecisionView decisionView=new DecisionView(decision);
       AddElement(decisionView);
    }
}
