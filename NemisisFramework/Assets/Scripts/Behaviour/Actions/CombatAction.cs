using UnityEngine;

public class CombatAction : Action
{
    public int energycost=20;
    public int animationlayer=0;
    public string animationname;   
    public float transitiontime=0.3f;
    
    float attacktime;
    float counter;
    
    public override void onEnter(StateController controller)
    {
        counter=0;        
        controller.anim.applyRootMotion=true;
        controller.flagHandler.isattacking=true;
        
        if(controller.agent)
            controller.agent.isStopped=true;

        float yaw=controller.GetComponent<CameraInputHandler>().target.eulerAngles.y;
        controller.transform.rotation=Quaternion.Euler(new Vector3(controller.transform.rotation.x,yaw,controller.transform.rotation.z));

        attacktime=controller.anim.GetCurrentAnimatorStateInfo(0).length;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime);
    }
    public override void Act(StateController controller)
    {
        if(counter<attacktime)
            counter+=Time.deltaTime;
    }
    public override void FixedAct(StateController controller){}
    public override void onExit(StateController controller)
    {
        counter=0;
       
        controller.anim.applyRootMotion=false;
        
        if(controller.agent)
            controller.agent.isStopped=false;
         
    }

}
