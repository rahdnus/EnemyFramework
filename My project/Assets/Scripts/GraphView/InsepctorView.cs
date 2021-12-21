using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
public class InsepctorView : VisualElement
{new public class UxmlFactory:UxmlFactory<InsepctorView,VisualElement.UxmlTraits>{}

    Editor editor;
    internal void updateNodeChange(NodeView nodeview)
    {
        Clear();
        UnityEngine.Object.DestroyImmediate(editor);
        UnityEngine.Object targetobject=new UnityEngine.Object();
        if(nodeview.GetType()==typeof(ActionView))
        {
        var actionview=nodeview as ActionView;
        targetobject=actionview.action;
        }
        else if(nodeview.GetType()==typeof(StateView))
        {
        var stateview=nodeview as StateView;
        targetobject=stateview.state;
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
