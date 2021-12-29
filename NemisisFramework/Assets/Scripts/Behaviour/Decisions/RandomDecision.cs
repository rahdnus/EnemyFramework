using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDecision : Decision
{

[Range(0,9)]
   [SerializeField]int truetofalse; 
  public override bool decide(StateController controller)
  {
      Random.InitState(System.DateTime.Now.Millisecond);
      int odds=Random.Range(0,10);
      Debug.Log(odds);
      if(odds<=truetofalse)
      {
          return true;
      }
      return false;
  }
  
  
}
