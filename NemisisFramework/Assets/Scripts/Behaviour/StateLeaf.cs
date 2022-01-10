using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="StateLeaf")]


public class StateLeaf : StateTree
{
   public Traversable currentstate;
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
   public void changeCurrentState(State newstate,StateController controller)
   {
       if(newstate!=null)
       {
           Debug.Log(currentstate.name+controller.tree.name);
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
   
    
}
