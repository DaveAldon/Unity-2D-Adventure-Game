using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoad {
	public static List<Game> savedGames = new List<Game>();

	public static void Save() {
		savedGames.Add(Game.current); //adds current game session to the list of "savedGames"
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //creates custom file with our own extension "gd"
		bf.Serialize(file, SaveLoad.savedGames);
		file.Close();

		//note that Application.persistentDataPath is the default path location of save files for Unity3d. Calling on this allows this code to be multiplatform without worrying about special paths
	}

	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
			SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
			file.Close();
		}
	}

}