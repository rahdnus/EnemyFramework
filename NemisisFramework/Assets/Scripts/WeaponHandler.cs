using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]Collider weaponCollider;
    public void setColliderstatus(int state)
    {
        bool status=(state==1);
        weaponCollider.enabled=status;
    }
}
