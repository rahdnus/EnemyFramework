using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.Callbacks;


public class StateTreeEditor : EditorWindow
{
    StateTreeView treeView;
    InsepctorView inspectorview;
    
    [MenuItem("StateTreeEditor/Editor.")]
    public static void OpenWindow()
    {
        StateTreeEditor wnd = GetWindow<StateTreeEditor>();
        wnd.titleContent = new GUIContent("StateTreeEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if (Selection.activeObject is StateTree)
        {
            OpenWindow();

            return true;
        }
        return false;
    }
    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
         
        // VisualElements objects can contain other VisualElement following a tree hierarchy.

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/GraphView/StateTreeEditor.uxml");
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/GraphView/StateTreeEditor.uss");
        root.styleSheets.Add(styleSheet);

        inspectorview=root.Q<InsepctorView>();
        treeView=root.Q<StateTreeView>();

        treeView.OnSelected=OnNodeSelectionChanged;
        treeView.OnTreeSelected=OnTreeSelectionChanged;

        OnSelectionChange();
    }
    private void OnNodeSelectionChanged(NodeView node)
    {
        inspectorview.updateNodeChange(node);
    }
    private void OnSelectionChange()
    {
        changeTree();   
    }
    private void OnTreeSelectionChanged(NodeView node)
    {
        if(node.GetType()==typeof(StateTreeNodeView))
        {
            StateTreeNodeView view=node as StateTreeNodeView;
            changeTree(view.branch);
        }
         if(node.GetType()==typeof(StateLeafNodeView))
        {
            StateLeafNodeView view=node as StateLeafNodeView;
            changeTree(view.leaf);
        }
    }
 
    private void changeTree(StateTree newtree=null)
    {
        
        StateTree tree=newtree;
        if(tree==null)
        {        
            tree=Selection.activeObject as StateTree;
        }

        if(tree && AssetDatabase.CanOpenForEdit(tree))
        {
            treeView.PopulateView(tree);
        }
    }

}