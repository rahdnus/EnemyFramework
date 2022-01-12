using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
public class InsepctorView : VisualElement
{new public class UxmlFactory:UxmlFactory<InsepctorView,VisualElement.UxmlTraits>{}

    Editor editor;
    internal void updateNodeChange(NodeView nodeview)
    {
        Clear();
        UnityEngine.Object.DestroyImmediate(editor);
        UnityEngine.Object targetobject=new UnityEngine.Object();
        Debug.Log(nodeview.GetType());
        if(nodeview.GetType()==typeof(StateView))
        {
        var stateview=nodeview as StateView;
        targetobject=stateview.state;
        }
        else if(nodeview.GetType()==typeof(StateLeafNodeView))
        {
            var leafview=nodeview as StateLeafNodeView;
            targetobject=leafview.leaf;
        }
        if(nodeview.GetType()==typeof(StateTreeNodeView))
        {
            var branchview=nodeview as StateTreeNodeView;
            targetobject=branchview.branch;
        }
        else if(nodeview.GetType()==typeof(EndStateView))
        {
            var endview=nodeview as EndStateView;
            targetobject=endview.end;
        }
        else if(nodeview.GetType()==typeof(StartStateView))
        {
        var startview=nodeview as StartStateView;
        targetobject=startview.start;
        }
        else if(nodeview.GetType()==typeof(ActionView))
        {
        var actionview=nodeview as ActionView;
        targetobject=actionview.action;
        }
      
        else if(nodeview.GetType()==typeof(DecisionView))
        {
        var decisionview=nodeview as DecisionView;
        targetobject=decisionview.decision;
        }
        else if(nodeview.GetType()==typeof(TransitionView))
        {
        var transitionview=nodeview as TransitionView;
        targetobject=transitionview.transition;
        }

        editor=Editor.CreateEditor(targetobject);
        IMGUIContainer container=new IMGUIContainer(()=>editor.OnInspectorGUI());
        Add(container);
    }
}
