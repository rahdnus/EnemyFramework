using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Action/Combat_Act")]
public class CombatAction : Action
{
    public Attack attacks;
    public override void Act(StateController controller)
    {
        attacks.attack(controller);
    }

}
