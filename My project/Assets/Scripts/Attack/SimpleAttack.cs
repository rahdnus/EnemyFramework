using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PlugAI/Attack/Simple_Atk")]
public class SimpleAttack : Attack
{
    public AnimationCurve xmotion;
    public AnimationCurve zmotion;
    bool animationplaying=false;
    public override void attack(StateController controller)
    {
        if(!animationplaying)
        {
            controller.GetComponent<Animator>().SetTrigger("JumpAttack");
            animationplaying=true;
        }
    }
}
