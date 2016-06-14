using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

	public bool triggerGUI = false;

	void OnTriggerEnter2D(Collider2D c) { //2D trigger function needs to receive a 2D collider
		if(c.gameObject.tag == "Player") { //We only want the player to be able to activate checkpoints
			//Destroy(transform.gameObject); //Destroy the checkpoint
			Debug.Log("Triggered Object");
			GlobalController.Instance.globalsActiveSave.save = 1;
			triggerGUI = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		triggerGUI = false;
		Debug.Log("Left checkpoint");
	}

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

	void OnGUI() {
		if(triggerGUI == true) {
			GUILayout.Space(500);
			if (GUILayout.Button ("Save")) {
				GlobalController.Instance.globalsActiveSave.save = 1;
				GlobalController.Instance.Save (1);
			}
		}
	}
}
