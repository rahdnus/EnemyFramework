using System.Collections;
using System.Reflection;
using UnityEngine;

public class AnimateAction : Action
{
    public int animationlayer=0;
    public string animationname;   
    public float transitiontime=0.3f;
    public string methodname;
    public string physicsmethodname;
    public object[] args;
    public KeyCode input;
   public override void onEnter(StateController controller)
    {
       if(input==KeyCode.None)
       {
           controller.anim.CrossFadeInFixedTime(animationname,transitiontime,animationlayer);
           InvokeMethod(controller,methodname);
       }
       //temp find more elegant solution
       if(controller.entity.GetType()==typeof(Enemy))
       {
           Enemy me=controller.entity as Enemy;
           me.agent.isStopped=true;
       }
    }
    public override void Act(StateController controller)
    {
        if((Input.GetKey(input)&& controller.flagHandler.animationflag==false))
        {
            controller.anim.CrossFadeInFixedTime(animationname,transitiontime,animationlayer);
            InvokeMethod(controller,methodname);
            controller.flagHandler.animationflag=true;  
        }  
    }
    public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {
               //temp find more elegant solution
        if(controller.entity.GetType()==typeof(Enemy))
       {
           Enemy me=controller.entity as Enemy;
           me.agent.isStopped=false;
       }
    }
    void InvokeMethod(StateController controller,string methodname)
    {
         if (methodname.Length > 0)
            {
                System.Type type = controller.entity.GetType();
                MethodInfo method = type.GetMethod(methodname);
                method.Invoke(controller.entity, null);
            }
    }
}
