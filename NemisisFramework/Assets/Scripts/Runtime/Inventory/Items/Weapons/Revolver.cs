using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
   [SerializeField]float range=30;
    public override void Attack()
    {
         RaycastHit hit;
            Debug.DrawRay(Camera.main.transform.position,Camera.main.transform.forward,Color.green,0.4f);
            
            int index;
            index=Random.Range(0,audioClips.GetLength(0));
            audioSource.PlayOneShot(audioClips[index]);
            
            if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit,range))
            {
               IDamagable collider=hit.collider.GetComponent<IDamagable>();
               if(collider!=null)
                collider.TakeDamage(damager.damagerIndex,20);
             //  StartCoroutine(delayshot(hit));
            }
    }
     
}
