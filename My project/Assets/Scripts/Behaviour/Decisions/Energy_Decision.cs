using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy_Decision : Decision
{

    [SerializeField]float minEnergy=100;
   
  public override bool decide(StateController controller)
  {
      if(controller.energy >minEnergy)
      {
          return true;
      }
      return false;
  }
  
  

}
