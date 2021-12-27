using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMoveAction : Action
{
    Vector3[] circlePoints;
    int nextpoint;

    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f; 

    [SerializeField] float speed=2;

    float agentstoppingdistance;
    public override void onEnter(StateController controller)
    {
        
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        calculatePointsOnCircle(controller);

        controller.agent.speed=speed;
        controller.agent.updateRotation=false;
        agentstoppingdistance=controller.agent.stoppingDistance;
        controller.agent.stoppingDistance=0;
        controller.agent.autoBraking=false;

        nextpoint=0;
    }
    public override void Act(StateController controller)
    {
       if(!(nextpoint>=circlePoints.Length))
       {
        if(!controller.agent.pathPending && controller.agent.remainingDistance<0.1f || !controller.agent.hasPath)
        {
            controller.agent.SetDestination(circlePoints[nextpoint]);
            Debug.Log("set destination");
            nextpoint++;
        } 
       }
       Quaternion rotation=Quaternion.LookRotation(controller.Target.position-controller.transform.position,controller.transform.up);
       controller.transform.rotation=rotation;
    }
    public override void onExit(StateController controller)
    {
        controller.agent.updateRotation=true;
        controller.agent.autoBraking=true;
        controller.agent.stoppingDistance=agentstoppingdistance;
    }
    private void calculatePointsOnCircle(StateController controller)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        circlePoints = new Vector3[Random.Range(3, 7)];

        Vector3 target = controller.Target.position;
        float radius = Mathf.Abs(Vector3.Distance(target, controller.transform.position));
        float xoffset = controller.transform.position.x - target.x;

        float angleoffset = 15;
        float angle = Mathf.Acos(xoffset / radius) * 180 / Mathf.PI;
        GameObject pointparent=new GameObject();
        for (int i = 0; i < circlePoints.Length; i++)
        {
            // Debug.Log("point");
            float radians = angle * Mathf.PI / 180;
            circlePoints[i].x = radius * Mathf.Cos(radians) + target.x;
            circlePoints[i].z = radius * Mathf.Sin(radians) + target.z;
            circlePoints[i].y = controller.transform.position.y;

            GameObject pointobject = new GameObject(i.ToString());
            pointobject.transform.parent = pointparent.transform;
            pointobject.transform.position = circlePoints[i];

            // Debug.Log(angle);
            angle += angleoffset;
        }
    }
   
}
