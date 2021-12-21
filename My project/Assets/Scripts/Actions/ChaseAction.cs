
using UnityEngine;
public class ChaseAction : Action
{
    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f;
    public override void onEnter(StateController controller)
    {
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        controller.GetComponent<UnityEngine.AI.NavMeshAgent>().speed+=4;
    }
    public override void Act(StateController controller)
    {
        controller.agent.destination=controller.Target.position;
    }
}
