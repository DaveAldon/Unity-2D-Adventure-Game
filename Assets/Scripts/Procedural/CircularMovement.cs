using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour  {

	public Transform center;
	public float degreesPerSecond = -70.0f;

	private Vector3 v;

	void Start() {
		center = GameObject.Find ("WeatherLeader").transform;
		v = transform.position - center.position;
	}

	void Update () {
		v = Quaternion.AngleAxis (degreesPerSecond * Time.deltaTime, Vector3.forward) * v;
		transform.position = center.position + v;
	}
}