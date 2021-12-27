using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMoveAction : Action
{
    float pathradius=5;
    Transform[] pointTransforms;

    [SerializeField]string statename="Slow_Run";
    [SerializeField]float transtitiontime=1.2f;

    [SerializeField] float Speed=4;
    public override void onEnter(StateController controller)
    {

        controller.GetComponent<Animator>().CrossFadeInFixedTime(statename,transtitiontime);
//        pathradius=Mathf.Abs(Vector3.Distance(controller.transform.position,controller.Target.position));
        calculatePointsOnCircle(controller);
        controller.agent.speed=Speed;
        controller.agent.updateRotation=false;
    }
    public override void Act(StateController controller)
    {
        
    }
    public override void onExit(StateController controller)
    {
        controller.agent.updateRotation=true;
    }
    private void calculatePointsOnCircle(StateController controller)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Vector3[] points=new Vector3[Random.Range(3,7)];
        pointTransforms=new Transform[points.Length];

        float angleoffset=15;
        float angle=15;
        for(int i=0;i<points.Length;i++)
        {
           // Debug.Log("point");
           float radians=angle*Mathf.PI/180;
            points[i].x=pathradius*Mathf.Cos(radians)+controller.transform.position.x;
            points[i].z=pathradius*Mathf.Sin(radians)+controller.transform.position.z;
            points[i].y=controller.transform.position.y;
            Debug.Log(points[i]);

            GameObject pointobject=new GameObject(i.ToString());
            pointobject.transform.parent=controller.transform;
            pointobject.transform.position=points[i];
            pointTransforms[i]=pointobject.transform;

           // Debug.Log(angle);
            angle+=angleoffset;
        }
    }
}
