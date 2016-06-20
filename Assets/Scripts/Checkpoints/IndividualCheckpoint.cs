﻿using UnityEngine;
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
			triggerGUI = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		triggerGUI = false;
	}

	void OnGUI() {
		if(triggerGUI == true) {
			GUILayout.Space(500);
			if (GUILayout.Button ("Click to Save Checkpoint")) {
				CheckpointManager.Instance.unlockedCheckpoint (checkpointID);
				GlobalController.Instance.Save (GlobalController.Instance.globalsActiveSave.save);
				Debug.Log(GlobalController.Instance.globalsActiveSave.save.ToString());
			}
		}
	}
}
