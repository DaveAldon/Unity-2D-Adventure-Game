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
		//Assign 2D coordinates of a parent prefab to the childrens' for instantiation
		lowFollowx = GameObject.Find ("WeatherLeader").transform.position.x - 2;
		highFollowx = GameObject.Find ("WeatherLeader").transform.position.x + 2;
		lowFollowy = GameObject.Find ("WeatherLeader").transform.position.y - 2;
		highFollowy = GameObject.Find ("WeatherLeader").transform.position.y + 2;
		generateFollowers();
	}

	//Called to instantiate a set amount of child prefabs
	void generateFollowers() {

		Vector3[] positions = new Vector3[10]; //We need to declare the array in a method and not the class, or the index won't 
						       //be able to be accessed correctly
		
		//Assign game world coordinates to the array of vectors
		for (int i = 0; i < 10; i++) {
			positions[i] = new Vector3(Random.Range (lowFollowx, highFollowx), Random.Range (lowFollowy, highFollowy), 0);
		}

		//Spawn the prefabs
		for (int i = 0; i < 10; i++) {
			Instantiate(follower, positions[i], Quaternion.identity);
		}
	}
}
