
using UnityEngine;

public class RechargeAction : Action
{
    float counter;
    public float rechargeamount=10;
    public override void onEnter(StateController controller)
    {
        counter=0;
    }
    public override void Act(StateController controller)
    {
        if( controller.energy<controller.maxenergy)
        {
            counter += Time.deltaTime;
            if (counter > 1)
            {
                counter = 0;
                controller.energy += rechargeamount;
            }
            if (controller.energy > controller.maxenergy)
            {
                controller.energy = controller.maxenergy;
            }
        }
       
    }
    public override void onExit(StateController controller)
    {
    }
}
