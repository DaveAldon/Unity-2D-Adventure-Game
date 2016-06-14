using UnityEngine;
using System.Collections;

public class SaveGame {

	public static SaveGame Instance;

	public void save(int slot) { //slot is a number that corrisponds with the active save file
		PlayerState.Instance.localPlayerData.SceneID = Application.loadedLevel;
		PlayerState.Instance.localPlayerData.PositionX = SpriteCharacterController.Instance.transform.position.x;
		PlayerState.Instance.localPlayerData.PositionY = SpriteCharacterController.Instance.transform.position.y;
		PlayerState.Instance.localPlayerData.PositionZ = SpriteCharacterController.Instance.transform.position.z;
		GlobalController.Instance.Save(slot);
	}
}
