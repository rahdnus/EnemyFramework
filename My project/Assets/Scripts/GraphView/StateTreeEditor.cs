using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;


public class StateTreeEditor : EditorWindow
{
    StateTreeView treeView;
    InsepctorView inspectorview;
    [MenuItem("StateTreeEditor/Editor..")]
    public static void OpenWindow()
    {
        StateTreeEditor wnd = GetWindow<StateTreeEditor>();
        wnd.titleContent = new GUIContent("StateTreeEditor");
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

        treeView=root.Q<StateTreeView>();
        inspectorview=root.Q<InsepctorView>();
        treeView.OnSelected=OnNodeSelectionChanged;

        OnSelectionChange();
    }
    private void OnSelectionChange()
    {
        StateTree tree=Selection.activeObject as StateTree;
        if(tree && AssetDatabase.CanOpenForEdit(tree))
        {
            treeView.PopulateView(tree);
        }
    }
    public void OnNodeSelectionChanged(NodeView node)
    {
        inspectorview.updateNodeChange(node);
    }

}