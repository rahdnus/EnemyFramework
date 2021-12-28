
using UnityEngine;
public class ChaseAction : Action
{
    [SerializeField]string blendname="Move";

    [SerializeField] System.Collections.Generic.List<SpeedRange> ranges=new System.Collections.Generic.List<SpeedRange>();
    [SerializeField] float ChaseSpeed=4;
    public override void onEnter(StateController controller)
    {
        controller.GetComponent<Animator>().CrossFadeInFixedTime(blendname,0.5f);
    }
    public override void Act(StateController controller)
    {
        foreach(SpeedRange range in ranges)
        {
            if(Mathf.Abs(Vector3.Distance(controller.Target.position,controller.transform.position))>range.mindistance)
            {
                controller.GetComponent<UnityEngine.AI.NavMeshAgent>().speed=range.speed;
                break;
            }
        }
          controller.GetComponent<Animator>().SetFloat("Vel",controller.agent.speed);
        controller.agent.destination=controller.Target.position;
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {

    }
    [System.Serializable]
    public class SpeedRange
    {
        public float speed;
        public float mindistance;
    }
}
