using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using System.Linq;
using System.Collections.Generic;

public class StateTreeView : GraphView
{
    public System.Action<NodeView> OnSelected;
    public System.Action<NodeView> OnTreeSelected;
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
      
        base.BuildContextualMenu(evt);
        if(tree.GetType()==typeof(StateBranch))
            evt.menu.AppendAction("StateBranch", (a) => createObject(typeof(StateBranch)));
             evt.menu.AppendAction("StateLeaf", (a) => createObject(typeof(StateLeaf)));
        if(tree.GetType()==typeof(StateLeaf))
        {
            evt.menu.AppendAction("State", (a) => createObject(typeof(State)));
            evt.menu.AppendAction("Transition", (a) => createObject(typeof(Transition)));

            evt.menu.AppendSeparator("---ACTIONS----");
            TypeCache.TypeCollection actiontypes = TypeCache.GetTypesDerivedFrom<Action>();
            actiontypes.ToList().ForEach((t) => evt.menu.AppendAction(t.Name, (b) => createObject(t)));

            evt.menu.AppendSeparator("---DECISIONS---");
            TypeCache.TypeCollection decisiontypes = TypeCache.GetTypesDerivedFrom<Decision>();
            decisiontypes.ToList().ForEach((t) => evt.menu.AppendAction(t.Name, (b) => createObject(t)));
        }
        
           


    }
    public void PopulateView(StateTree tree)
    {
        this.tree = tree;
       
        graphViewChanged -= GraphViewChanged;
        DeleteElements(graphElements.ToList());
        graphViewChanged += GraphViewChanged;

        if(tree.GetType()==typeof(StateBranch))
        {
            StateBranch branch=tree as StateBranch;
            branch.subtrees.ForEach(t =>
                {
                    if(t.GetType()==typeof(StateBranch))CreateStateTreeNodeView(t as StateBranch);
                    else if(t.GetType()==typeof(StateLeaf))CreateStateLeafNodeView(t as StateLeaf);

                   
                });
        }
        else if(tree.GetType()==typeof(StateLeaf))
        {
            StateLeaf leaf=tree as StateLeaf;
            leaf.states.ForEach(s =>{if(s)CreateStateView(s);});
            leaf.actions.ForEach(a=>{if(a)CreateActionView(a);});
            leaf.transitions.ForEach(t=>{if(t)CreateTransitionView(t);});
            leaf.decisions.ForEach(d=>{if(d)CreateDecisionView(d);});
        }

        
       

       #region populate_edge
       if(tree.GetType()==typeof(StateLeaf))
       {

       StateLeaf leaf=tree as StateLeaf;
       if(leaf.states!=null)
       leaf.states.ForEach(s=>
       {
           StateView stateView=GetNodeByGuid(s.guid)as StateView;
           if(s.actions!=null)
           s.actions.ForEach(a=>
           {
               ActionView actionView=GetNodeByGuid(a.guid) as ActionView;
               Edge edge=actionView.output.ConnectTo(stateView.A_input);

               

               AddElement(edge);
           });
       });

        if(leaf.states!=null)
        leaf.states.ForEach(s=>
       {
           StateView stateView=GetNodeByGuid(s.guid)as StateView;
           if(s.transitions!=null)
           s.transitions.ForEach(a=>
           {
               TransitionView transitionView=GetNodeByGuid(a.guid) as TransitionView;
               Edge edge=transitionView.output.ConnectTo(stateView.T_input);
               AddElement(edge);
           });
       });

        if(leaf.transitions!=null)
       leaf.transitions.ForEach(t=>
       {
           TransitionView transitionView=GetNodeByGuid(t.guid) as TransitionView;
           var decision=transitionView.transition.decision;
           if(decision!=null)
           {
            DecisionView decisionView=GetNodeByGuid(decision.guid) as DecisionView;
            // Debug.Log("decisin edge");
            Edge edge=decisionView.output.ConnectTo(transitionView.D_input);
            AddElement(edge);
           }
           
       });
       if(leaf.transitions!=null)
       leaf.transitions.ForEach(t=>
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
       #endregion
    
    }
    private new GraphViewChange GraphViewChanged(GraphViewChange graphViewChange)
    {
        if(graphViewChange.edgesToCreate!=null)
        {
            foreach(Edge edge in graphViewChange.edgesToCreate)
            {
                #region create_edge
                    if(edge.output.node.GetType()==typeof(ActionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        ActionView actionView=edge.output.node as ActionView;
                        // Debug.Log(stateView.name);
                            // stateView.state.actions.ForEach((action)=>{Debug.Log(action.name);});
                        stateView.state.actions.Add(actionView.action);
                        if(!stateView.state.name.Contains(actionView.title.Substring(0,actionView.title.Length-6)))
                            stateView.state.name+="_"+actionView.title.Remove(actionView.title.Length-6);
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
                #endregion
                    
            }
        }
        if(graphViewChange.elementsToRemove!=null)
        {
            foreach(GraphElement elem in graphViewChange.elementsToRemove)
            {
                #region remove_SO_data
                if (tree.GetType() == typeof(StateLeaf))
                {
                    StateLeaf leaf = tree as StateLeaf;
                    

                    if (elem.GetType() == typeof(StateView))
                    {
                        StateView view = elem as StateView;
                        leaf.RemoveState(view.state);
                    }
                    if (elem.GetType() == typeof(ActionView))
                    {
                        ActionView view = elem as ActionView;
                        leaf.RemoveAction(view.action);
                    }
                    if (elem.GetType() == typeof(TransitionView))
                    {
                        TransitionView view = elem as TransitionView;
                        leaf.RemoveTransition(view.transition);
                    }
                    if (elem.GetType() == typeof(DecisionView))
                    {
                        DecisionView view = elem as DecisionView;
                        leaf.RemoveDecision(view.decision);
                    }
                }
                else if (tree.GetType() == typeof(StateBranch))
                {
                    StateBranch branch = tree as StateBranch;
                    if (elem.GetType() == typeof(StateTreeNodeView))
                    {
                        StateTreeNodeView view = elem as StateTreeNodeView;
                        branch.RemoveBranch(view.branch);
                    }
                }
                #endregion
  
                #region remove_edge
                if(elem.GetType()==typeof(Edge))
                {
                    if (tree.GetType() == typeof(StateLeaf))
                    {
                    Edge edge=elem as Edge;
                    if(edge.output.node.GetType()==typeof(ActionView) && edge.input.node.GetType()==typeof(StateView))
                    {
                        StateView stateView=edge.input.node as StateView;
                        ActionView actionview=edge.output.node as ActionView;
                        Debug.Log("Action Removed");
                        stateView.state.actions.Remove(actionview.action);
                        stateView.state.name=stateView.state.name.Remove(stateView.state.name.Length-(actionview.action.name.Length-5));
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
                        TransitionView transitionView=edge.input.node as TransitionView;
                        Debug.Log("Decision Removed");
                        transitionView.transition.decision=null;
                    } 
                    if(edge.output.node.GetType()==typeof(StateView) && edge.input.node.GetType()==typeof(TransitionView))
                    {
                        TransitionView transitionView=edge.input.node as TransitionView;
                         Debug.Log("Edge Removed");
                        if(edge.input.portName=="True")
                        {
                           transitionView.transition.truestate=null;
                        }
                        else if(edge.input.portName=="False")
                        {
                           transitionView.transition.falsestate=null;
                        }
                    }
                    }
                }
                #endregion
                
            }
        }
        PopulateView(this.tree);
        
        return graphViewChange;
    }
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
    {
       return ports.ToList().Where(endport=>endport.direction!=startPort.direction).ToList();
    }

    void createObject(System.Type type)
    {
        #region create SO(type)
        if (tree.GetType() == typeof(StateLeaf))
        {

            StateLeaf leaf = tree as StateLeaf;

            if (type == typeof(State))
            {
                State state = leaf.CreateState();
                // state.position=Input.mousePosition;

                CreateStateView(state);
            }
            else if (type == typeof(Transition))
            {
                Transition transition = leaf.CreateTransition(type);
                // transition.position=Input.mousePosition;
                CreateTransitionView(transition);
            }
            else if (type.BaseType == typeof(Decision))
            {
                Decision decision = leaf.CreateDecision(type);
                CreateDecisionView(decision);
            }
            else if (type.BaseType == typeof(Action))
            {
                Action action = leaf.CreateAction(type);
                // action.position=Input.mousePosition;
                CreateActionView(action);
            }
        }
        else if (tree.GetType() == typeof(StateBranch))
        {
            StateBranch branch = tree as StateBranch;
            if (type == typeof(StateBranch))
            {
                StateBranch newbranch = branch.CreateStateBranch() as StateBranch;
                // state.position=Input.mousePosition;

                CreateStateTreeNodeView(newbranch);
            }
             if(type==typeof(StateLeaf))
            {
                StateLeaf leaf=branch.CreateStateLeaf() as StateLeaf;
                CreateStateLeafNodeView(leaf);
            }
        }
        #endregion
    }
    #region Create View
     void CreateStateTreeNodeView(StateBranch branch)
    {
        StateTreeNodeView statetreenodeview = new StateTreeNodeView(branch);
        statetreenodeview.onTreeSelected=OnTreeSelected;
        AddElement(statetreenodeview);
    }
     void CreateStateLeafNodeView(StateLeaf leaf)
    {
        StateLeafNodeView statetreenodeview = new StateLeafNodeView(leaf);
        statetreenodeview.onTreeSelected=OnTreeSelected;
        AddElement(statetreenodeview);
    }

    void CreateStateView(State state)
    {
        StateView stateview = new StateView(state);
        stateview.onNodeSelected=OnSelected;
        AddElement(stateview);
    }
    void CreateActionView(Action action)
    {
        ActionView actionview = new ActionView(action);
        actionview.onNodeSelected=OnSelected;
        AddElement(actionview);
    }
     void CreateTransitionView(Transition transition)
    {
        TransitionView transitionView= new TransitionView(transition);
        transitionView.onNodeSelected=OnSelected;
        AddElement(transitionView);
    }
    void CreateDecisionView(Decision decision)
    {
       DecisionView decisionView=new DecisionView(decision);
       decisionView.onNodeSelected=OnSelected;
       AddElement(decisionView);
    }
    #endregion
   
   
    // void createState(System.Type type)
    // {
    //     State state = tree.CreateState();
    //     CreateStateView(state);
    // }
    // void createAction(System.Type type)
    // {
    //     Action action=tree.CreateAction(type);
        
    //     CreateActionView(action);
    // }
    //  void createTranstion(System.Type type)
    // {
    //   Transition transition=tree.CreateTransition(type);
    //   CreateTransitionView(transition);
    // }
    // void createDecision(System.Type type)
    // {
    //   Decision decision=tree.CreateDecision(type);
    //   CreateDecisionView(decision);
    // }
}
