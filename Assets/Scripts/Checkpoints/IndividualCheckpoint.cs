using UnityEngine;
using System.Collections;

public class IndividualCheckpoint : MonoBehaviour {

	public int checkpointID = 1;
	public bool triggerGUI = false;
	public string checkpointName = "";

	void Start() {
		checkpointName = getCheckpointName();
	}

	public string getCheckpointName() {
		return CheckpointManager.getCheckpointName(checkpointID);
	}

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
