using UnityEngine;
using System.Collections;

public class IndividualCheckpoint : MonoBehaviour {

	public int checkpointID = 1;
	public bool triggerCheckpointGUI = false;
	public bool travelTriggerGUI = false;
	public string checkpointName = "";

	void Start() {
		checkpointName = getCheckpointName();
	}

	public string getCheckpointName() {
		return CheckpointManager.getCheckpointName(checkpointID);
	}

	void OnTriggerEnter2D(Collider2D c) { //2D trigger function needs to receive a 2D collider
		if(c.gameObject.tag == "Player") { //We only want the player to be able to activate checkpoints
			triggerCheckpointGUI = true;
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		triggerCheckpointGUI = false;
	}

	void OnGUI() {
		if(triggerCheckpointGUI) {
			GUILayout.Space(500);
			if (!GlobalController.Instance.unlockedCheckpoints.Contains (checkpointID)) {
				if (GUILayout.Button ("Click to Save Checkpoint")) {				
					CheckpointManager.Instance.unlockedCheckpoint (checkpointID);
					Debug.Log (GlobalController.Instance.globalsActiveSave.save.ToString ());
					travelTriggerGUI = true;
				}
			} else if (GlobalController.Instance.unlockedCheckpoints.Contains (checkpointID)) { //Test
				GUILayout.Label ("Unlocked");
				travelTriggerGUI = true;
			}
			if(travelTriggerGUI) {
				if (GUILayout.Button ("Travel to Hub")) {
					travelTriggerGUI = false;
					UnityEngine.SceneManagement.SceneManager.LoadScene("Hub");
				}
			}
		}
	}
}
