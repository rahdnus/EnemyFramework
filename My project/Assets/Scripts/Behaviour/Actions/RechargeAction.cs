
using UnityEngine;

public class RechargeAction : Action
{
    float counter;
    public int rechargeamount=10;
    public override void onEnter(StateController controller)
    {
        counter=0;
    }
    public override void Act(StateController controller)
    {
        Debug.Log("Recovering");

        if( controller.energy<controller.maxenergy)
        {
            counter += Time.deltaTime;
            if (counter > 1)
            {
                counter = 0;
                controller.energy += rechargeamount;
                Debug.Log("Recovering");
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
