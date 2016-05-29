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
	public static List<playerLocation> savedLocations = new List<playerLocation>();

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
			SaveLocationToBinary ();

		}

		if(GUI.Button(new Rect(20,70,80,20), "Load Location")) {
			target.position = new Vector3 (savedPlayerPosition.x, savedPlayerPosition.y, 0);
		}
	}
		
	public void SaveLocationToBinary() {
		UpdateLocation ();
		savedLocations.Add(playerLocation.locPosition); //adds current game session to the list of "savedGames"
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //creates custom file with our own extension "gd"
		bf.Serialize(file, SaveLoad.savedGames);
		file.Close();
		Debug.Log (savedLocations);

		//note that Application.persistentDataPath is the default path location of save files for Unity3d. Calling on this allows this code to be multiplatform without worrying about special paths
	}
}

public class playerLocation {
	public float locX, locY, locZ;

	public playerLocation() {
		locX = SavingPlayerLocation.savedPlayerPosition.x;
		locY = SavingPlayerLocation.savedPlayerPosition.y;
		locZ = SavingPlayerLocation.savedPlayerPosition.z;
		locPosition = new Vector3 (locX, locY, locZ);
	}
} 