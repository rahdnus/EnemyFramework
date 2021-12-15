using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="StateTree")]
public class StateTree : ScriptableObject
{
   public List<State> states=new List<State>();
   List<Action> actions=new List<Action>();

   public State CreateState()
   {
       State state=CreateInstance<State>();
       state.name="hello";
       state.guid=GUID.Generate().ToString();
        states.Add(state);
       AssetDatabase.AddObjectToAsset(state,this);
       AssetDatabase.SaveAssets();
       return state;
   }
   public void RemoveState(State state)
   {
       states.Remove(state);
       AssetDatabase.RemoveObjectFromAsset(state);
       AssetDatabase.SaveAssets();
   }
   
}
