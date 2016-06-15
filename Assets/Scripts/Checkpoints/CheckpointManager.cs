using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

	public string getCheckpointName(int checkpointID) {
		if (checkpointID == 1) {
			return "Start Position";
		} else if (checkpointID == 2) {
			return "North Checkpoint";
		} else if (checkpointID == 3) {
			return "East Checkpoint";
		} else
			return "You don't have a checkpoint saved";
	}
}
