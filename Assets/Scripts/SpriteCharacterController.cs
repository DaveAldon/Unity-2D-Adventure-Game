using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpriteCharacterController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingForward = true;
	public float playerSpeed = 10f;
	public static SpriteCharacterController Instance;
	public CheckpointCoordinate checkpointCoordinates = new CheckpointCoordinate(); //New class deriving from the base CheckpointCoordinate class which holds only x, y, and z floats

	void Start() {
		if (GlobalController.Instance.IsSceneBeingLoaded) { //If the scene is being loaded via a saved game file
			PlayerState.Instance.localPlayerData = GlobalController.Instance.LocalCopyOfData; //Passes saved data to the player
			transform.position = new Vector3( //Updates the player location based on the saved data
				GlobalController.Instance.LocalCopyOfData.PositionX,
				GlobalController.Instance.LocalCopyOfData.PositionY,
				GlobalController.Instance.LocalCopyOfData.PositionZ
			);

			GlobalController.Instance.unlockedCheckpoints = PlayerState.Instance.localPlayerData.unlockedCheckpoints;
			GlobalController.Instance.IsSceneBeingLoaded = false; //Turns the bool off in case the player loads their game during the same application session
		}

		if (GlobalController.Instance.IsCheckpointBeingActivated) { //If the scene is being loaded via a checkpoint
			checkpointCoordinates = CheckpointManager.getCheckpointCoordinates(GlobalController.Instance.whatCheckpointIsLoading); //Sets the x,y, and z values equal to the appropriate floats once the checkpoint's ID is given to the coordinate retriever function
			transform.position = new Vector3(
				checkpointCoordinates.x,
				checkpointCoordinates.y,
				checkpointCoordinates.z
			);

			GlobalController.Instance.IsCheckpointBeingActivated = false; //Turns the bool off in case the player loads different checkpoints during the same game. Because of the nature of the game, this will probably happen often in order to travel
		}
	}

	void FixedUpdate () {
		Controls (); //Activates the Controls function that checks for keyboard input every frame. We will keep these functions seperate for ease of maintenance
	}

	void flip()//Flipping the sprite and animation backwards
	{
		facingForward = !facingForward;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Controls()
	{
		if (Input.GetKey ("up")) {//Press up arrow key to move forward on the Y AXIS
			transform.Translate (0, playerSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey ("down")) {
			transform.Translate (0, -playerSpeed * Time.deltaTime, 0);
		}
		if (Input.GetKey ("right")) {
			transform.Translate (playerSpeed * Time.deltaTime, 0, 0);
		}
		if (Input.GetKey ("left")) {
			transform.Translate (-playerSpeed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKeyDown ("space")) {
			CheckpointManager.showCheckpoints = true;
		}
		if (Input.GetKeyUp ("space")) {
			CheckpointManager.showCheckpoints = false;
		} 
	}

	public void loadGame(int slot) {
		GlobalController.Instance.Load(slot);
		GlobalController.Instance.IsSceneBeingLoaded = true;
		int whatScene = GlobalController.Instance.LocalCopyOfData.SceneID;
		SceneManager.LoadScene (whatScene);
	}

	public void save(int slot) {
		PlayerState.Instance.localPlayerData.characterName = GlobalController.Instance.characterName;
		PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
		PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
		PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
		PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;
		PlayerState.Instance.localPlayerData.unlockedCheckpoints = GlobalController.Instance.unlockedCheckpoints;
		GlobalController.Instance.Save(slot);
	}

	void OnGUI() { //These buttons are for use during development in order to easily manipulate the activation of functions
		if(GUILayout.Button("Save 1")) {
			save(1);
			GlobalController.Instance.globalsActiveSave.save = 1;
		}
		if(GUILayout.Button("Save 2")) {
			save(2);
			GlobalController.Instance.globalsActiveSave.save = 2;
		}
		if(GUILayout.Button("Save 3")) {
			save(3);
			GlobalController.Instance.globalsActiveSave.save = 3;
		}
		if(GUILayout.Button("Load 1")) {
			loadGame(1);
			GlobalController.Instance.globalsActiveSave.save = 1;
		}
		if(GUILayout.Button("Load 2")) {
			loadGame(2);
			GlobalController.Instance.globalsActiveSave.save = 2;
		}
		if(GUILayout.Button("Load 3")) {
			loadGame(3);
			GlobalController.Instance.globalsActiveSave.save = 3;
		}
		if (GUILayout.Button ("Unlock Checkpoint 0")) {
			CheckpointManager.Instance.unlockedCheckpoint (0);
		}
		if (GUILayout.Button ("Unlock Checkpoint 1")) {
			CheckpointManager.Instance.unlockedCheckpoint (1);
		}
		if (GUILayout.Button ("Unlock Checkpoint 2")) {
			CheckpointManager.Instance.unlockedCheckpoint (2);
		}
		if (GUILayout.Button ("Unlock Checkpoint 3")) {
			CheckpointManager.Instance.unlockedCheckpoint (3);
		}
	}
}