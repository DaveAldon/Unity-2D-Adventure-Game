using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

	public static CheckpointManager Instance;
	public static bool showCheckpoints = false;
	public List<int> unlockedCheckpoints = new List<int>();
	public CheckpointCoordinate checkpointCoordinates = new CheckpointCoordinate();

	public static string getCheckpointName(int checkpointID) {
		if (checkpointID == 0) {
			return "Start Position";
		} else if (checkpointID == 1) {
			return "North Checkpoint";
		} else if (checkpointID == 2) {
			return "East Checkpoint";
		} else
			return "Incorrect Checkpoint ID";
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
		return CheckpointManager.Instance.checkpointCoordinates;
	}

	public static int getUnlockedCheckpoints(int checkpointID) {
		return CheckpointManager.Instance.unlockedCheckpoints.IndexOf (checkpointID);
	}

	void OnGUI() {
		if (showCheckpoints) {
			if(0 < GlobalController.Instance.savedPlayerData.unlockedCheckpointList.Count) {
				GUILayout.TextArea (getUnlockedCheckpoints(1).ToString() + getCheckpointName(1));
			}
			else {
				GUILayout.TextArea("Nothing in list");
			}
		}
	}

	public void unlockedCheckpoint(int checkpointID) {
		this.unlockedCheckpoints.Add (checkpointID);
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