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
        controller.reacheddestination=false;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        calculatePointsOnCircle(controller);

        controller.agent.speed=speed;
        controller.agent.updateRotation=false;
        agentstoppingdistance=controller.agent.stoppingDistance;
        controller.agent.stoppingDistance=0;
        controller.agent.autoBraking=false;
        controller.agent.ResetPath();

        nextpoint=0;
    }
    public override void Act(StateController controller)
    {
       if(!(nextpoint==circlePoints.Length))
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
       if(nextpoint==circlePoints.Length)
       {
           controller.reacheddestination=true;
       }
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {  

        controller.agent.SetDestination(controller.Target.position);
        controller.agent.updateRotation=true;
        controller.agent.ResetPath();
        controller.agent.autoBraking=true;
        controller.agent.stoppingDistance=agentstoppingdistance;
        controller.reacheddestination=false;
        nextpoint=0;
    }
    private void calculatePointsOnCircle(StateController controller)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        circlePoints = new Vector3[Random.Range(3, 7)];

        Vector3 target = controller.Target.position;
        float radius = Mathf.Abs(Vector3.Distance(target, controller.transform.position));
        float xoffset = controller.transform.position.x - target.x;
        float zoffset = controller.transform.position.z- target.z;

        float offset=xoffset;

        float angleoffset = 15;
        
        float angle = Mathf.Atan2(zoffset ,xoffset) * 180 / Mathf.PI;

        // Debug.Log(angle+" "+xoffset);

        // GameObject pointparent=new GameObject();
        for (int i = 0; i < circlePoints.Length; i++)
        {
            // Debug.Log("point");
            float radians = angle * Mathf.PI / 180;
            circlePoints[i].x = radius * Mathf.Cos(radians) + target.x;
            circlePoints[i].z = radius * Mathf.Sin(radians) + target.z;
            circlePoints[i].y = controller.transform.position.y;

       /*     GameObject pointobject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointobject.name=i.ToString();
            pointobject.transform.parent = pointparent.transform;
            pointobject.transform.position = circlePoints[i];*/
            
            // Debug.Log(angle);
            angle += angleoffset;
        }
    }
   
}
