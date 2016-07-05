using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

	public static CheckpointManager Instance;
	public static bool showCheckpoints = false;
	public CheckpointCoordinate checkpointCoordinates = new CheckpointCoordinate(); //New class deriving from the base CheckpointCoordinate class which holds only x, y, and z floats

	public static string getCheckpointName(int checkpointID) { //Recieves a CheckpointID and returns a string depending on what the checkpoint's name needs to be
		if (checkpointID == 0) {
			return "Start Position";
		} else if (checkpointID == 1) {
			return "North Checkpoint";
		} else if (checkpointID == 2) {
			return "East Checkpoint";
		} else
			return "Incorrect Checkpoint ID " + checkpointID; //This is for if the checkpointID essentially doesn't correspond with an existing checkpoint. During development we would like to know if something is strange
	}

	public static CheckpointCoordinate getCheckpointCoordinates(int checkpointID) {
		if (checkpointID == 0) {
			CheckpointManager.Instance.checkpointCoordinates.x = 0;
			CheckpointManager.Instance.checkpointCoordinates.y = 0;
			CheckpointManager.Instance.checkpointCoordinates.z = 0;
		} else if (checkpointID == 1) {
			CheckpointManager.Instance.checkpointCoordinates.x = 10;
			CheckpointManager.Instance.checkpointCoordinates.y = 10;
			CheckpointManager.Instance.checkpointCoordinates.z = 0;
		} else if (checkpointID == 2) {
			CheckpointManager.Instance.checkpointCoordinates.x = -10;
			CheckpointManager.Instance.checkpointCoordinates.y = -10;
			CheckpointManager.Instance.checkpointCoordinates.z = 0;
		}
		return CheckpointManager.Instance.checkpointCoordinates; //Because there are multiples values we need returned, everything is placed in a class, and the entire class is returned
	}

	public static int getUnlockedCheckpoints(int checkpointID) {
			return GlobalController.Instance.unlockedCheckpoints[checkpointID];
	}

	void OnGUI() {
		if (showCheckpoints) {
			if(0 < GlobalController.Instance.savedPlayerData.unlockedCheckpoints.Count) {
			}
			else {
				GUILayout.TextArea("Nothing in list");
			}
		}
	}

	public void unlockedCheckpoint(int checkpointID) {
		GlobalController.Instance.unlockedCheckpoints.Add (checkpointID);
		GlobalController.Instance.sortCheckpointUnlocks ();
	}

	void Awake () { //This singleton keeps the object this script is attached to from being destroyed when switching scenes
		if (Instance == null) {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this) {
			Destroy (gameObject);
		}
	}
}