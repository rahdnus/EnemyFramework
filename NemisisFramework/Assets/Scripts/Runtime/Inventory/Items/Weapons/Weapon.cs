using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Damager))]
public abstract class Weapon : Item
{
 [SerializeField] protected Damager damager;//for eventual lookup table
 [SerializeField] protected AudioSource audioSource;
 [SerializeField]protected AudioClip[] audioClips;
 public virtual void Attack(){}

public void Start()
{
    damager = GetComponent<Damager>();
}

}
