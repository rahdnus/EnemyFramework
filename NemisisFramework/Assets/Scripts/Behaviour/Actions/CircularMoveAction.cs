using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMoveAction : Action
{
    Vector3[] circlePoints;
    int nextpoint;
    
    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f; 

    Enemy me;
    [SerializeField] float speed=2;

    float agentstoppingdistance;
    public override void onEnter(StateController controller)
    {
        controller.flagHandler.reacheddestination=false;
        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
        calculatePointsOnCircle(controller);

        me=controller.entity as Enemy;
        me.agent.speed=speed;
        me.agent.updateRotation=false;
        agentstoppingdistance=me.agent.stoppingDistance;
        me.agent.stoppingDistance=0;
        me.agent.autoBraking=false;
        me.agent.ResetPath();

        nextpoint=0;
    }
    public override void Act(StateController controller)
    {
       if(!(nextpoint==circlePoints.Length))
       {
        if(!me.agent.pathPending && me.agent.remainingDistance<0.1f || !me.agent.hasPath)
        {
            me.agent.SetDestination(circlePoints[nextpoint]);
            Debug.Log("set destination");
            nextpoint++;
        } 
        
       }
     
       Quaternion rotation=Quaternion.LookRotation(me.target.position-controller.transform.position,controller.transform.up);
       controller.transform.rotation=rotation;
       if(nextpoint==circlePoints.Length)
       {
           controller.flagHandler.reacheddestination=true;
       }
    }
     public override void FixedAct(StateController controller)
    {

    }
    public override void onExit(StateController controller)
    {  

        me.agent.SetDestination(me.target.position);
        me.agent.updateRotation=true;
        me.agent.ResetPath();
        me.agent.autoBraking=true;
        me.agent.stoppingDistance=agentstoppingdistance;
        controller.flagHandler.reacheddestination=false;
        nextpoint=0;
    }
    private void calculatePointsOnCircle(StateController controller)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        circlePoints = new Vector3[Random.Range(3, 7)];

        Vector3 target = me.target.position;
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
