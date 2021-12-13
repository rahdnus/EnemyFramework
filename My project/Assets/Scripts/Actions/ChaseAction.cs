using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Action/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        controller.agent.destination=controller.Target.position;
    }
}
