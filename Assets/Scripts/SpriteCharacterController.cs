using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpriteCharacterController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingForward = true;
	public float playerSpeed = 10f;
	public static SpriteCharacterController Instance;

	void Start() {
		if (GlobalController.Instance.IsSceneBeingLoaded) {
			PlayerState.Instance.localPlayerData = GlobalController.Instance.LocalCopyOfData;

			transform.position = new Vector3(
				GlobalController.Instance.LocalCopyOfData.PositionX,
				GlobalController.Instance.LocalCopyOfData.PositionY,
				GlobalController.Instance.LocalCopyOfData.PositionZ);

			GlobalController.Instance.IsSceneBeingLoaded = false;
		}
	}

	void FixedUpdate () {
		Controls (); // Player Movement
	}

	void flip()//flipping the sprite and animation backwards
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

	public void loadGame(string slot) {
		GlobalController.Instance.Load(slot);
		GlobalController.Instance.IsSceneBeingLoaded = true;
		int whatScene = GlobalController.Instance.LocalCopyOfData.SceneID;
		SceneManager.LoadScene (whatScene);
		CheckpointManager.Instance.unlockedCheckpointList = GlobalController.Instance.savedPlayerData.unlockedCheckpointList;
	}

	public void save(int slot) {
		PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
		PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
		PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
		PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;
		GlobalController.Instance.savedPlayerData.unlockedCheckpointList = CheckpointManager.Instance.unlockedCheckpointList;
		GlobalController.Instance.Save(slot);
	}

	void OnGUI() { 
		if(GUILayout.Button("Save 1")) {
			save (1);
			GlobalController.Instance.globalsActiveSave.save = 1;
		}
		if(GUILayout.Button("Save 2")) {
			save (2);
			GlobalController.Instance.globalsActiveSave.save = 2;
		}
		if(GUILayout.Button("Save 3")) {
			save (3);
			GlobalController.Instance.globalsActiveSave.save = 3;
		}

		if(GUILayout.Button("Load 1")) {
			loadGame("1");
			GlobalController.Instance.globalsActiveSave.save = 1;
		}
		if(GUILayout.Button("Load 2")) {
			loadGame("2");
			GlobalController.Instance.globalsActiveSave.save = 2;
		}
		if(GUILayout.Button("Load 3")) {
			loadGame("3");
			GlobalController.Instance.globalsActiveSave.save = 3;
		}
		if (GUILayout.Button ("Unlock Checkpoint 1")) {
			CheckpointManager.Instance.unlockedCheckpoint (1);

		}
	}
}