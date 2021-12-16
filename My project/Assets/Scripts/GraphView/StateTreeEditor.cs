using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class StateTreeEditor : EditorWindow
{
    StateTreeView treeView;
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

        OnSelectionChange();
    }
    private void OnSelectionChange()
    {
        StateTree tree=Selection.activeObject as StateTree;
        if(tree)
        {
            treeView.PopulateView(tree);
        }
    }

}