using UnityEngine;
using System.Collections;

public class SpriteCharacterController : MonoBehaviour {


	public float maxSpeed = 10f;
	bool facingForward = true;
	public float playerSpeed = 10f;

	// Use this for initialization
	void Start () {
	
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
	}
}
