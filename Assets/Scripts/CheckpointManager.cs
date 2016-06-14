using UnityEngine;
using System.Collections;

public class CheckpointManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c) { //2D trigger function needs to receive a 2D collider
		if(c.gameObject.tag == "Player") { //We only want the player to be able to activate checkpoints
			Destroy(transform.gameObject); //Destroy the checkpoint
			Debug.Log("Triggered Object and Destroyed Checkpoint");
			GlobalController.Instance.globalsActiveSave.save = 1;
		}
	}

	public string getCheckpointName() {

	}
}
