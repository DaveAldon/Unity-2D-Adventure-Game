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
		MoveForward (); // Player Movement
	}

	void flip()//flipping the sprite and animation backwards
	{
		facingForward = !facingForward;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void MoveForward()
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
	
		if (Input.GetKeyUp (KeyCode.A)) {
			//saveGame();
		}

		if (Input.GetKeyUp (KeyCode.S)) {
			//loadGame();
		}
	}

	public void loadGame(int slot) {
		GlobalController.Instance.Load(Application.persistentDataPath + "/Saves/save_" + slot + ".gd");
		GlobalController.Instance.IsSceneBeingLoaded = true;
		int whatScene = GlobalController.Instance.LocalCopyOfData.SceneID;
		SceneManager.LoadScene (whatScene);
	}

	public void saveGame(int slot) {
		PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
		PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
		PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
		PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;
		GlobalController.Instance.Save(slot);
	}

	void OnGUI() {
		if(GUILayout.Button("Save 1")) {
			saveGame(1);
		}
		if(GUILayout.Button("Save 2")) {
			saveGame(2);
		}
		if(GUILayout.Button("Save 3")) {
			saveGame(3);
		}

		if(GUILayout.Button("Load 1")) {
			loadGame(1);
		}
		if(GUILayout.Button("Load 2")) {
			loadGame(2);
		}
		if(GUILayout.Button("Load 3")) {
			loadGame(3);
		}
	}
}