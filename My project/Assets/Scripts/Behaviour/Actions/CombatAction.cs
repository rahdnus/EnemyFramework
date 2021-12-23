using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatAction : Action
{
    public string animationname;   
    public int energycost=20;
    public int animationlayer=0;
    public float transitiontime=0.3f;
    bool animationflag=true; 
    float counter=0;
    public override void onEnter(StateController controller)
    {
        // animationflag=true;
        // counter=0;
        controller.agent.isStopped=true;
        controller.isattacking=true;
            controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime-0.001f);
            // animationflag=false;
            // Debug.Log("Depleting");
    }
    public override void Act(StateController controller)
    {
        // if(animationflag)
        // {
        //     controller.GetComponent<Animator>().CrossFadeInFixedTime(animationname, transitiontime-0.001f);//because of the counter>transitiontime
        //     // animationflag=false;
        // }
        // counter+=Time.deltaTime;
        // if(counter>transitiontime)
        // {
        // if(controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(animationlayer).IsName(animationname) 
        //     && controller.GetComponent<Animator>().GetCurrentAnimatorStateInfo(animationlayer).normalizedTime>=1f)
        //     {
        //     animationflag=true;
        //     Debug.Log("Depleting");
        //      controller.energy-=energycost;
        //      counter=0;
        //     }
        // }
        
    }
    public override void onExit(StateController controller)
    {
       controller.agent.isStopped=false;
    }

}
