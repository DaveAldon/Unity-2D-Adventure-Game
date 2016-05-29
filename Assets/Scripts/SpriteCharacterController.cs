using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpriteCharacterController : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingForward = true;
	public float playerSpeed = 10f;

	// Use this for initialization
	/*void Start () {
		if (GlobalController.Instance.IsSceneBeingLoaded) {
			PlayerState.Instance.localPlayerData = GlobalController.Instance.LocalCopyOfData;

			transform.position = new Vector3(
				GlobalController.Instance.LocalCopyOfData.PositionX,
				GlobalController.Instance.LocalCopyOfData.PositionY,
				GlobalController.Instance.LocalCopyOfData.PositionZ);

			GlobalController.Instance.IsSceneBeingLoaded = false;
		}
	}*/

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
	
		if (Input.GetKey(KeyCode.A)) {
			PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
			PlayerState.Instance.localPlayerData.PositionX = transform.position.x;
			PlayerState.Instance.localPlayerData.PositionY = transform.position.y;
			PlayerState.Instance.localPlayerData.PositionZ = transform.position.z;

			GlobalController.Instance.Save();
		}

		if (Input.GetKey (KeyCode.S)) {
			GlobalController.Instance.Load ();
			GlobalController.Instance.IsSceneBeingLoaded = true;

			int whatScene = GlobalController.Instance.LocalCopyOfData.SceneID;

			SceneManager.LoadScene (whatScene);
		}
	}
}
