using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HubControl : MonoBehaviour {

	public static HubControl Instance;
	public bool triggerGUI = false;
	public string checkpointName = "";
	public List<int> hubCheckpoints = new List<int> ();
	public CheckpointCoordinate buttonCoordinates = new CheckpointCoordinate (); //New class deriving from the base CheckpointCoordinate class which holds only x, y, and z floats

	void Start() {
		hubCheckpoints = CheckpointManager.Instance.unlockedCheckpoints; //Assigns the list values from the global controller to the hub controller9
	}

	void OnTriggerEnter2D(Collider2D c) { //2D trigger function needs to receive a 2D collider
		if(c.gameObject.tag == "Player") { //We only want the player to be able to activate checkpoints
			triggerGUI = true; //Shows the approprate buttons in OnGUI
		}
	}

	void OnTriggerExit2D(Collider2D c) {
		triggerGUI = false; //turns off the buttons made by the loop
	}

	void OnGUI() {
		if(triggerGUI == true) {
			GUILayout.Space(500);
			for (int i = 0; i < hubCheckpoints.Count; i++) {
				if (GUI.Button (new Rect (500, i * 30, 200, 20), CheckpointManager.getCheckpointName(CheckpointManager.getUnlockedCheckpoints(i)))) {
					buttonCoordinates = CheckpointManager.getCheckpointCoordinates (i);
					GlobalController.Instance.whatCheckpointIsLoading = i; //Sets a global number that is used by the SpriteCharacterController in order to manage checkpoint coordinate loading
					GlobalController.Instance.IsCheckpointBeingActivated = true; //SpriteCharacterController checks if this is true on start in order to activate checkpoint coordinate functions
					UnityEngine.SceneManagement.SceneManager.LoadScene("1");
					//triggerGUI = false; 
				}
			}

			if (GUILayout.Button ("Click to Save Checkpoint")) {
				GlobalController.Instance.Save (GlobalController.Instance.globalsActiveSave.save); //Saves the current game state whenever a checkpoint is saved. Anything done in between is lost on purpose in order to focus on checkpoint based gameplay.
				Debug.Log(GlobalController.Instance.globalsActiveSave.save.ToString()); //Shows us which game save was just used
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

