using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    public bool takingdamage=false;
    public bool reacheddestination=false;
    public bool isattacking=false;
    public bool animationflag=false;
      public void setAnimationFlag()
    {
        animationflag=false;
    }
     public void setisBeingAttacked()
    {
        takingdamage=false;
    }
    public void setIsAttacking()
    {
        isattacking=false;
       
    }
}
