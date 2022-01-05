using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="StateBranch")]
public class StateBranch : StateTree
{
    public List<StateTree> subtrees=new List<StateTree>();
    public StateBranch CreateStateBranch()
   {
       StateBranch branch=CreateInstance<StateBranch>();
       branch.guid=GUID.Generate().ToString();
        subtrees.Add(branch);
       branch.name=subtrees.Count.ToString()+".Branch";
       AssetDatabase.AddObjectToAsset(branch,this);
       AssetDatabase.SaveAssets();
       return branch;
   }
    public StateLeaf CreateStateLeaf()
   {
       StateLeaf leaf=CreateInstance<StateLeaf>();
       leaf.guid=GUID.Generate().ToString();
        subtrees.Add(leaf);
       leaf.name=subtrees.Count.ToString()+".Leaf";
       AssetDatabase.AddObjectToAsset(leaf,this);
       AssetDatabase.SaveAssets();
       return leaf;
   }
      public void RemoveBranch(StateTree tree)
   {
       
       subtrees.Remove(tree);
       AssetDatabase.RemoveObjectFromAsset(tree);
       AssetDatabase.SaveAssets();
   }
}
