using UnityEngine;

public class CombatAction : Action
{
    public int energycost=20;
    public int animationlayer=0;
    public string animationname;   
    public float transitiontime=0.3f;
    
    
    
    public override void onEnter(StateController controller)
    {
        
        controller.anim.applyRootMotion=true;
        controller.flagHandler.animationflag=true;
        controller.entity.preAttack();
        controller.anim.CrossFadeInFixedTime(animationname, transitiontime,animationlayer);
    }
    public override void Act(StateController controller)
    {
    }
    public override void FixedAct(StateController controller){}
    public override void onExit(StateController controller)
    {
        controller.anim.applyRootMotion=false;
        controller.entity.postAttack();
         
    }

}
