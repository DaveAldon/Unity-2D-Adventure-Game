using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class GlobalController : MonoBehaviour {

	public static GlobalController Instance;

	public PlayerStatistics savedPlayerData = new PlayerStatistics();
	public PlayerStatistics LocalCopyOfData;

	public bool IsSceneBeingLoaded = false;

	public GameObject player;
	public int SceneID;
	public float PositionX, PositionY, PositionZ;
	public float HP;
	public string characterName;

	private int saveNumber = 1; //Used to make saveFileName unique later during calculation
	private string saveFileName = ""; //saveFileName must be initialized without saveNumber before the two can be used together in a calculation

	public void Save() { //note that Application.persistentDataPath is the default path location of save files for Unity3d. Calling on this allows this code to be multiplatform without worrying about special paths
		if (!Directory.Exists(Application.persistentDataPath + "/Saves")) {
			Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
		}

		saveFileName = "save_" + saveNumber + ".gd";
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves/" + saveFileName);
		LocalCopyOfData = PlayerState.Instance.localPlayerData;
		formatter.Serialize(saveFile, LocalCopyOfData);
		saveFile.Close();
		saveNumber++;
	}

	public void Load(string saveName) {
		BinaryFormatter formatter = new BinaryFormatter();
		FileStream loadedFile = File.Open(saveName, FileMode.OpenOrCreate);
		LocalCopyOfData = (PlayerStatistics)formatter.Deserialize(loadedFile);
		loadedFile.Close();
		UnityEngine.SceneManagement.SceneManager.LoadScene(1);
		player = GameObject.Find("Character");
	}

	void Awake () { //This singleton keeps the object this script is attached to from being destroyed when switching scenes
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}
}