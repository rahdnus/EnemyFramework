using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="StateLeaf")]


public class StateLeaf : StateTree
{
   public Traversable currentstate;
      public List<Transition> childtransitions=new List<Transition>();
    public List<Decision> childdecisions=new List<Decision>();
   public List<State> states=new List<State>();
   public List<Action> actions=new List<Action>();
   

   public override void onEnter(StateController controller)
   {
      // currentstate=startNode;
      currentstate.onEnter(controller);
      // currentstate.onEnter(controller);
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
       currentstate=startNode;
   }
   public void changeCurrentState(Traversable newstate,StateController controller)
   {
       if(newstate!=null)
       {
           Debug.Log(newstate.name+controller.tree.name);
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
           public Transition CreateTransition(System.Type type)
   {
       Transition transition=CreateInstance(type) as Transition;
       transition.name="transition";
       transition.guid=GUID.Generate().ToString();
       childtransitions.Add(transition);
       AssetDatabase.AddObjectToAsset(transition,this);
       AssetDatabase.SaveAssets();
       return transition;
   }
       public Decision CreateDecision(System.Type type)
   {
       Decision decision=CreateInstance(type) as Decision;
       decision.name=type.Name;
       decision.guid=GUID.Generate().ToString();
       childdecisions.Add(decision);
       AssetDatabase.AddObjectToAsset(decision,this);
       AssetDatabase.SaveAssets();
       return decision;
   }
    public void RemoveTransition(Transition transition)
   {
       childtransitions.Remove(transition);
        AssetDatabase.RemoveObjectFromAsset(transition);
       AssetDatabase.SaveAssets();
   }
   public void RemoveDecision(Decision decision)
   {
       childdecisions.Remove(decision);
        AssetDatabase.RemoveObjectFromAsset(decision);
       AssetDatabase.SaveAssets();
   }
   
    
}
