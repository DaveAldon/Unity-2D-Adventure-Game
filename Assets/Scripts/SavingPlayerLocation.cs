using UnityEngine;
using System.Collections;

public class SavingPlayerLocation : MonoBehaviour {
	public Transform target;
	public Vector3 playerCurrentLocation;
	public Vector3 savedPlayerPosition;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update () {
		playerCurrentLocation.x = target.position.x;
		playerCurrentLocation.y = target.position.y;
	}
	// Update is called once per frame

	void OnGUI () {
		GUI.Box (new Rect (10, 10, 100, 90), "Location Manager");

		if(GUI.Button(new Rect(20,40,80,20), "Save Location")) {
			savedPlayerPosition.x = playerCurrentLocation.x;
			savedPlayerPosition.y = playerCurrentLocation.y;

		}

		if(GUI.Button(new Rect(20,70,80,20), "Load Location")) {
			target.position = new Vector3 (savedPlayerPosition.x, savedPlayerPosition.y, 0);
		}
	}
}