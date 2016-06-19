using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

	//public static List<int> unlockedCheckpointList = new List<int>();
	public static CheckpointManager Instance;
	public static bool showCheckpoints = false;
	public List<int> unlockedCheckpointList = new List<int>();

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
		return CheckpointManager.Instance.unlockedCheckpointList [checkpointID];
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
		this.unlockedCheckpointList.Add (checkpointID);
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