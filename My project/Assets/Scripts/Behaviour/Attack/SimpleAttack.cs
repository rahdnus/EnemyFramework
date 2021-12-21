using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlugAI/Attack/Simple_Atk")]
public class SimpleAttack : Attack
{
    public override void attack(StateController controller)
    {
        controller.GetComponent<Animator>().SetTrigger("JumpAttack");
    }
}
