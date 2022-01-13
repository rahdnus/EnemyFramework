using System;
using UnityEngine.UIElements;
using UnityEngine;

public class TreeGraphView : NodeView
{
    public System.Action<TreeGraphView> onDoubleClick;
    float clicktime=0;
    bool hasbeensleected=false;
   public override void OnSelected()
   {
    base.OnSelected();
       
   }
   public override void OnUnselected()
   {
        if(clicktime==0)
       {
        clicktime=DateTime.Now.Second+DateTime.Now.Millisecond*0.001f;
       }
       else if((DateTime.Now.Second+DateTime.Now.Millisecond*0.001f)-clicktime<0.3f && (DateTime.Now.Second+DateTime.Now.Millisecond*0.001f)-clicktime>0.1f )
       {
      //  Debug.Log((DateTime.Now.Second+DateTime.Now.Millisecond*0.001f)-clicktime);
       onDoubleClick(this);
        clicktime=0;
       }
       else if((DateTime.Now.Second+DateTime.Now.Millisecond*0.001f)-clicktime>0.3)
       {
           clicktime=0;
       }
   }
   
}
