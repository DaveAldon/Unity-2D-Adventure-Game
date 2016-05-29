using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

[System.Serializable]
public class SavingPlayerLocation : MonoBehaviour {

	public Transform target;
	public Vector3 playerCurrentLocation;
	public static Vector3 savedPlayerPosition;
	public static List<Game> savedLocations = new List<Game>();

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	public void UpdateLocation() {
		playerCurrentLocation.x = target.position.x;
		playerCurrentLocation.y = target.position.y;
	}
	// Update is called once per frame

	void OnGUI() {
		GUI.Box (new Rect (10, 10, 100, 90), "Location Manager");

		if(GUI.Button(new Rect(20,40,80,20), "Save Location")) {
			UpdateLocation ();
			savedPlayerPosition.x = playerCurrentLocation.x;
			savedPlayerPosition.y = playerCurrentLocation.y;
		}

		if(GUI.Button(new Rect(20,70,80,20), "Load Location")) {
			target.position = new Vector3 (savedPlayerPosition.x, savedPlayerPosition.y, 0);
		}
	}
}