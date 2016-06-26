using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HubControl : MonoBehaviour {

	public static HubControl Instance;
	public bool triggerGUI = false;
	public string checkpointName = "";
	public List<int> hubCheckpoints = new List<int> ();
	public CheckpointCoordinate buttonCoordinates = new CheckpointCoordinate ();

	void Start() {
		hubCheckpoints = CheckpointManager.Instance.unlockedCheckpoints; //Assigns the list values from the global controller to the hub controller9
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
				if (GUI.Button (new Rect (500, i * 30, 200, 20), CheckpointManager.getCheckpointName(CheckpointManager.getUnlockedCheckpoints(i)))) {
					buttonCoordinates = CheckpointManager.getCheckpointCoordinates (i);
					GlobalController.Instance.whatCheckpointIsLoading = i;
					GlobalController.Instance.IsCheckpointBeingActivated = true;
					UnityEngine.SceneManagement.SceneManager.LoadScene("1");
					triggerGUI = false;
				}
			}

			if (GUILayout.Button ("Click to Save Checkpoint")) {
				GlobalController.Instance.Save (GlobalController.Instance.globalsActiveSave.save);
				Debug.Log(GlobalController.Instance.globalsActiveSave.save.ToString());
			}
		}
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

