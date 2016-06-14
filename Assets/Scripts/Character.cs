using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable] 
public class Character {

	public string characterName;
	public int[] unlockedLocations; //3 available checkpoints to unlock

	public Character () {
		this.characterName = "";
	}
}