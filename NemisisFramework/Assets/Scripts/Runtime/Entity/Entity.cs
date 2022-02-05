using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour,IDamagable
{
    int health=100;
    public float movementSpeed=1.5f;
    public Inventory inventory;
    public Weapon weapon;
    public Animator anim;
    public FlagHandler flaghandler;
    public Transform eyes;
    public Transform foot;
   // public GameObject weapon;
   //Scriptable Object LookUPTable for Sfx
    public LayerMask targetLayer;
    public virtual Vector3 getposition(){return Vector3.zero;}
    public virtual void Move(Vector3 position){}
    public virtual void preAttack(){}
    public virtual void Attack(){}
    public virtual void postAttack(){}
    protected virtual void Start()
    {
        flaghandler=GetComponent<FlagHandler>();
        anim=GetComponent<Animator>();
    }
    public virtual void TakeDamage(int damagerIndex,int damage)
    {
        flaghandler.takingdamage=true;
        health-=damage;
    }
}
