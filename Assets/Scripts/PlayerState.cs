using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerState : MonoBehaviour {
	public static PlayerState Instance;
	public int SceneID;
	public Transform playerPosition;
	public float PositionX, PositionY, PositionZ;
	public float HP;
	public string characterName;

	public PlayerStatistics localPlayerData = new PlayerStatistics();

	void Awake() {
		if (Instance == null)
			Instance = this;
		if (Instance != this)
			Destroy (gameObject);
			
		GlobalController.Instance.player = gameObject;
	}

	void Start () {   
		localPlayerData = GlobalController.Instance.savedPlayerData;
	}
}