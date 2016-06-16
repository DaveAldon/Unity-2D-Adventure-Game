using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour {

	public static List<int> unlockedCheckpointList = new List<int>();

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

	public static int getUnlockedCheckpoints() {
		if (unlockedCheckpointList.Count >= 0) {
			for (int i = 1; i < unlockedCheckpointList.Count; i++) {
				return unlockedCheckpointList [i];
			}
		}
	}

	public static void unlockedCheckpoint(int checkpointID) {
		unlockedCheckpointList.Add (checkpointID);
	}
}