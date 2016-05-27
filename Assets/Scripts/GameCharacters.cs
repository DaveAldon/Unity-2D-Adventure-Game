using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { 

	public static Game current; //static reference to a game instance
	public Character traveller;

	public Game () {
		traveller = new Character();
	}

}