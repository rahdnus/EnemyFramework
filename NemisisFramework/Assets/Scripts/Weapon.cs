using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float damage=10;
  void OnTriggerEnter(Collider collider)
  {
      Debug.Log(collider.name);
      IDamagable damagable=collider.GetComponent<IDamagable>();
      if(damagable!=null)
        damagable.TakeDamage(damage);
  }
}
