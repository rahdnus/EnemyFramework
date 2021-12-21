using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Decision/Observe")]
public class Observe_Decision : Decision
{
    public float observeRange=20f;
 public override bool decide(StateController controller)
 {
     RaycastHit hit;
    if(Physics.SphereCast(controller.transform.position,5,controller.transform.forward,out hit,observeRange,controller.targetlayer))
    {
        controller.Target=hit.collider.transform;
        return true;    
    }
    return false;
    
 }
}
