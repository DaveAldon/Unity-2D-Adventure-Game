using UnityEngine;
using System.Collections;

public class WeatherSpawner : MonoBehaviour {
	public float low = -10.0f;
	public float high = 10.0f;
	public float low2 = -10.0f;
	public float high2 = 10.0f;

	public float lowFollowx;
	public float highFollowx;
	public float lowFollowy;
	public float highFollowy;
			
	public GameObject leader;
	public GameObject follower;

	void Start() {
		lowFollowx = GameObject.Find ("WeatherLeader").transform.position.x - 2;
		highFollowx = GameObject.Find ("WeatherLeader").transform.position.x + 2;
		lowFollowy = GameObject.Find ("WeatherLeader").transform.position.y - 2;
		highFollowy = GameObject.Find ("WeatherLeader").transform.position.y + 2;
		generateFollowers();
	}
	/*
	public void generateLeader() {
		//Random.InitState (1);
		Vector3 eyeOfStormPos = new Vector3(Random.Range (low, high), Random.Range (low2, high2), 0);
		Instantiate(leader, eyeOfStormPos, Quaternion.identity);
		}
		*/

	public void generateFollowers() {

		Vector3[] positions = new Vector3[10]; //We need to declare the array in a method and not the class, or the index won't be able to be accessed correctly

		for (int i = 0; i < 9; i++) {
			positions[i] = new Vector3(Random.Range (lowFollowx, highFollowx), Random.Range (lowFollowy, highFollowy), 0);
		}

		for (int i = 0; i < 10; i++) {
			Instantiate(follower, positions[i], Quaternion.identity);
		}
	}
}
