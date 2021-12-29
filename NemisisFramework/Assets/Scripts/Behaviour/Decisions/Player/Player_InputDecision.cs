using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_InputDecision : Decision
{
    [SerializeField] List<KeyCode> codes=new List<KeyCode>();
    public override bool decide(StateController controller)
    {
        bool result=true;

        if(codes.Count>0)
            codes.ForEach(c=>result&=Input.GetKey(c));
        
        return result;
    }
}
