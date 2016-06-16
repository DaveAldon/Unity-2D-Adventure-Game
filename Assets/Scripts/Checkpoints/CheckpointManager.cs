using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

	//public int[] unlockedCheckpoints;

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

	public static int[] getUnlockedCheckpoints(int checkpointID)
	{
		int[] unlockedCheckpoints;
		unlockedCheckpoints = new int[3];

		return unlockedCheckpoints;
	}
}