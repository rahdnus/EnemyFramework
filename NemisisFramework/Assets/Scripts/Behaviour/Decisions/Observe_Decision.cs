using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="PlugAI/Decision/Observe")]
public class Observe_Decision : Decision
{
    public float observeRange=20f;
    Enemy enemy;
 public override bool decide(StateController controller)
 {
     RaycastHit hit;
    if(Physics.SphereCast(controller.entity.eyes.transform.position,5,controller.entity.eyes.transform.forward,out hit,observeRange,controller.entity.targetLayer))
    {
        enemy=controller.entity as Enemy;
        enemy.target=hit.collider.transform;
        return true;    
    }
    return false;
    
 }
}
