using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour {

	// put the points from unity interface
	public Transform[] wayPointList = new Transform[4];

	public int currentWayPoint = 0; 
	Transform targetWayPoint;

	public float speed = 4f;

	// Use this for initialization
	void Awake () {
		
	}

	// Update is called once per frame
	void Update () {
		// check if we have somewere to walk
		if(currentWayPoint < this.wayPointList.Length)
		{
			if(targetWayPoint == null)
				targetWayPoint = wayPointList[currentWayPoint];
			walk();
		}
	}

	void walk(){
		// rotate towards the target
		transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed*Time.deltaTime, 0.0f);

		// move towards the target
		transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position,   speed*Time.deltaTime);

		if(transform.position == targetWayPoint.position)
		{
			currentWayPoint ++ ;
			if (currentWayPoint >= wayPointList.Length) {
				currentWayPoint = 0;
			}
			targetWayPoint = wayPointList[currentWayPoint];
		}
	} 
}