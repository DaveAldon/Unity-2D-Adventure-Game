using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GlobalController : MonoBehaviour {

	public static GlobalController Instance;
	public PlayerStatistics savedPlayerData = new PlayerStatistics();
	public PlayerStatistics LocalCopyOfData;
	public ActiveSave globalsActiveSave = new ActiveSave();

	public bool IsSceneBeingLoaded = false;
	public bool IsCheckpointBeingActivated = false;

	public int whatSaveFileIsActive = 1;
	public int SceneID;
	public int whatCheckpointIsLoading = 0;
	public float PositionX, PositionY, PositionZ;
	public float HP;
	public string characterName;
	private string saveFileName = "";

	public void Start() {
	}

	public void Update() {
		whatSaveFileIsActive = GlobalController.Instance.globalsActiveSave.save;
	}

	public void Save(int slot) { //note that Application.persistentDataPath is the default path location of save files for Unity3d. Calling on this allows this code to be multiplatform without worrying about special paths
		if (!Directory.Exists(Application.persistentDataPath + "/Saves")) {
			Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
		}
		saveFileName = "save_" + slot + ".gd";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves/" + saveFileName);
		LocalCopyOfData = PlayerState.Instance.localPlayerData;
		formatter.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
		globalsActiveSave.save = slot;
		whatSaveFileIsActive = slot;
	}

	public void NewSave(int sceneid, string name, float X, float Y, float Z, int save) {

		GameObject prefab = Resources.Load<GameObject> ("Prefabs/Character");
		Instantiate (prefab, new Vector3 (X, Y, Z), Quaternion.identity);

		PlayerState.Instance.localPlayerData.SceneID = sceneid;
		PlayerState.Instance.localPlayerData.characterName = name;
		characterName = name;
		PlayerState.Instance.localPlayerData.PositionX = X;
		PlayerState.Instance.localPlayerData.PositionY = Y;
		PlayerState.Instance.localPlayerData.PositionZ = Z;

		saveFileName = "save_" + save + ".gd";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves/" + saveFileName);
		LocalCopyOfData = PlayerState.Instance.localPlayerData;
		formatter.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
	}

	public void LoadFromIndex(string slot) {
		string saveNames = slot; //Application.persistentDataPath + "/Saves/save_" + slot + ".gd";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream loadedFile = File.Open(saveNames, FileMode.OpenOrCreate);
		LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(loadedFile);
		loadedFile.Close();
		UnityEngine.SceneManagement.SceneManager.LoadScene("1");
	}

	public void Load(int slot) {
		string saveNames = Application.persistentDataPath + "/Saves/save_" + slot + ".gd";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream loadedFile = File.Open(saveNames, FileMode.OpenOrCreate);
		LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(loadedFile);
		loadedFile.Close();
		UnityEngine.SceneManagement.SceneManager.LoadScene("1");
	}

	void Awake () { //This singleton keeps the object this script is attached to from being destroyed when switching scenes
		if (Instance == null) {
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this) {
			Destroy (gameObject);
		}
	}
}