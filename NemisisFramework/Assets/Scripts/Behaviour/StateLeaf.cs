using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="StateLeaf")]


public class StateLeaf : StateTree
{
    State currentstate;
   public List<State> states=new List<State>();
   public List<Action> actions=new List<Action>();

   public List<Transition> transitions=new List<Transition>();
   public List<Decision> decisions=new List<Decision>();

   public override void onEnter(StateController controller)
   {
       currentstate=states[0];//temporary
       currentstate.onEnter(controller);
   }
    public override void update(StateController controller)
   {
       currentstate.update(controller);
   }
   public override void fixedUpdate(StateController controller)
   {
       currentstate.fixedUpdate(controller);
   }
    public override void onExit(StateController controller)
   {
       currentstate.onExit(controller);
   }
   public void changeCurrentState(State newstate,StateController controller)
   {
       if(newstate!=null)
       {
           currentstate.onExit(controller);
           currentstate=newstate;
           currentstate.onEnter(controller);
       }
   }
  public State CreateState()
   {
       State state=CreateInstance<State>();
       state.guid=GUID.Generate().ToString();
        states.Add(state);
       state.name=states.Count.ToString()+".State";
       AssetDatabase.AddObjectToAsset(state,this);
       AssetDatabase.SaveAssets();
       return state;
   }
   public Action CreateAction(System.Type type)
   {
       Action action=CreateInstance(type) as Action;
       action.name=type.Name;
       action.guid=GUID.Generate().ToString();
        actions.Add(action);
       AssetDatabase.AddObjectToAsset(action,this);
       AssetDatabase.SaveAssets();
       return action;
   }
      public Transition CreateTransition(System.Type type)
   {
       Transition transition=CreateInstance(type) as Transition;
       transition.name="transition";
       transition.guid=GUID.Generate().ToString();
       transitions.Add(transition);
       AssetDatabase.AddObjectToAsset(transition,this);
       AssetDatabase.SaveAssets();
       return transition;
   }
    public Decision CreateDecision(System.Type type)
   {
       Decision decision=CreateInstance(type) as Decision;
       decision.name=type.Name;
       decision.guid=GUID.Generate().ToString();
       decisions.Add(decision);
       AssetDatabase.AddObjectToAsset(decision,this);
       AssetDatabase.SaveAssets();
       return decision;
   }
   public void RemoveState(State state)
   {
       states.Remove(state);
       AssetDatabase.RemoveObjectFromAsset(state);
       AssetDatabase.SaveAssets();
   }
   public void RemoveAction(Action action)
   {
       actions.Remove(action);
        AssetDatabase.RemoveObjectFromAsset(action);
       AssetDatabase.SaveAssets();
   }
    public void RemoveTransition(Transition transition)
   {
       transitions.Remove(transition);
        AssetDatabase.RemoveObjectFromAsset(transition);
       AssetDatabase.SaveAssets();
   }
    public void RemoveDecision(Decision decision)
   {
       decisions.Remove(decision);
        AssetDatabase.RemoveObjectFromAsset(decision);
       AssetDatabase.SaveAssets();
   }
}
