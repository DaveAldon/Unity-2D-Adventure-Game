using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HubControl : MonoBehaviour {

	public bool triggerGUI = false;
	public string checkpointName = "";
	public List<int> hubCheckpoints = new List<int> ();

	void Start() {
		hubCheckpoints = CheckpointManager.Instance.unlockedCheckpoints;
		/*
		for (int i = 0; i < hubCheckpoints.Count; i++) {
			hubCheckpoints[i] = CheckpointManager.Instance.unlockedCheckpoints [i];
		}
		*/
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
			for (int i = 0; i < hubCheckpoints.Count; i++) {
				if (GUI.Button (new Rect (500, i * 30, 100, 20), "Button!")) {

				}
			}
			if (GUILayout.Button ("Click to Save Checkpoint")) {
				GlobalController.Instance.Save (GlobalController.Instance.globalsActiveSave.save);
				Debug.Log(GlobalController.Instance.globalsActiveSave.save.ToString());
			}
		}
	}
}

