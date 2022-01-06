using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="StateBranch")]
public class StateBranch : StateTree
{
    public List<StateTree> childgraphs=new List<StateTree>();
    public List<StateTree> siblinggraphs=new List<StateTree>();
    
    //call relevant child.onEnter till eventually reaching leaf
    //after traversing thru leafstates EXIT state must become currentstate
    //EXIT state has ref to predecessor, has oncomplete(statecontroller) which sets currenttraversable to predecsoor(called in onENter)
    public override void onEnter(StateController controller)
   {
      controller.changeCurrnetTree(childgraphs[0]);
   }
    public override void update(StateController controller)
   {
      // currentstate.Update(controller);
   }
   public override void fixedUpdate(StateController controller)
   {
      // currentstate.FixedUpdate(controller);
   }
    public override void onExit(StateController controller)
   {
     
   }

    public StateBranch CreateStateBranch()
   {
       StateBranch branch=CreateInstance<StateBranch>();
       branch.guid=GUID.Generate().ToString();
        childgraphs.Add(branch);
       branch.name=childgraphs.Count.ToString()+".Branch";
       AssetDatabase.AddObjectToAsset(branch,this);
       AssetDatabase.SaveAssets();
       return branch;
   }
    public StateLeaf CreateStateLeaf()
   {
       StateLeaf leaf=CreateInstance<StateLeaf>();
       leaf.guid=GUID.Generate().ToString();
        childgraphs.Add(leaf);
       leaf.name=childgraphs.Count.ToString()+".Leaf";
       AssetDatabase.AddObjectToAsset(leaf,this);
       AssetDatabase.SaveAssets();
       return leaf;
   }
      public void RemoveBranch(StateTree tree)
   {
       
       childgraphs.Remove(tree);
       AssetDatabase.RemoveObjectFromAsset(tree);
       AssetDatabase.SaveAssets();
   }
}
