using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagHandler : MonoBehaviour
{
    public bool isbeingattacked=false;
    public bool reacheddestination=false;
    public bool isattacking=false;
    public bool animationflag=false;
      public void setAnimationFlag()
    {
        animationflag=false;
    }
     public void setisBeingAttacked()
    {
        isbeingattacked=false;
    }
    public void setIsAttacking()
    {
        isattacking=false;
       
    }
}
