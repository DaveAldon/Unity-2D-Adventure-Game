using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

	//public static List<int> unlockedCheckpointList = new List<int>();
	public static CheckpointManager Instance;
	public static bool showCheckpoints = false;

	public static string getCheckpointName(int checkpointID) {
		if (checkpointID == 1) {
			return "Start Position";
		} else if (checkpointID == 2) {
			return "North Checkpoint";
		} else if (checkpointID == 3) {
			return "East Checkpoint";
		} else
			return "Incorrect Checkpoint ID";
	}

	public static int getUnlockedCheckpoints(int checkpointID) {
		return GlobalController.Instance.savedPlayerData.unlockedCheckpointList [checkpointID];
	}

	void OnGUI() {
		if (showCheckpoints) {
			GUILayout.TextArea (getUnlockedCheckpoints(1).ToString());
		}
	}

	public void unlockedCheckpoint(int checkpointID) {
		GlobalController.Instance.savedPlayerData.unlockedCheckpointList.Add (checkpointID);
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