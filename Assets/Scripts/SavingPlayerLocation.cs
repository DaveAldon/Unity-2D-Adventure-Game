using UnityEngine;
using System.Collections;

public class SavingPlayerLocation : MonoBehaviour {

	public Transform target;
	private Transform playerLocation;
	bool _hasBegun = false;

	void Start () {
		if (_hasBegun) {
			playerLocation.transform.position = new Vector3(0, 0, 0);
		}
	}
	// Update is called once per frame

	void OnGUI () {
		GUI.Box (new Rect (10, 10, 100, 90), "Location Manager");

		if(GUI.Button(new Rect(20,40,80,20), "Save Location")) {
			playerLocation.position = new Vector3();
		}

		if(GUI.Button(new Rect(20,70,80,20), "Load Location")) {
			target.position = playerLocation.transform.position;
		}
	}
}