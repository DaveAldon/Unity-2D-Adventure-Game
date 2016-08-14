using UnityEngine;
using System.Collections;

public class WeatherSpawner : MonoBehaviour {
	public float low = -10.0f;
	public float high = 10.0f;
	public float low2 = -10.0f;
	public float high2 = 10.0f;
			
	public GameObject leader;
	public GameObject follower;
	//public Vector3[] pubPositions = new Vector3[10];

	void Start() {
		generateFollowers();
	}

	public void generateLeader() {
		Random.InitState (1);
		Vector3 eyeOfStormPos = new Vector3(Random.Range (low, high), Random.Range (low2, high2), 0);
		Instantiate(leader, eyeOfStormPos, Quaternion.identity);
		}

	public void generateFollowers() {

		Vector3[] positions = new Vector3[10]; //We need to declare the array in a method and not the class, or the index won't be able to be accessed correctly

		for (int i = 0; i < 9; i++) {
			positions[i] = new Vector3(Random.Range (low, high), Random.Range (low2, high2), 0);
		}

		for (int i = 0; i < 10; i++) {
			Instantiate(follower, positions[i], Quaternion.identity);
		}
	}
}
