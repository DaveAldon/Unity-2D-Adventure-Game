using UnityEngine;  
using System.Collections;  
using System.Collections.Generic;  
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public enum Menu {
		MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;
	public string directoryPath;  
	private string fullFilePath;  
	private string dirOutputString = "";  
	private Vector2 scrollPosition = Vector2.zero;   
	private string fileNumberString = "0";
	private List<string> fileNames; //List that will store the game saves
	public bool loadListLock = false;

	private int newGameStartScene = 1;
	private string newPlayerName = "";
	private float newGameStartPosX = 0;
	private float newGameStartPosY = 0;
	private float newGameStartPosZ = 0;

	void OnGUI () {
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.MainMenu) {
			loadListLock = false;
			GUILayout.Box("2D Aventure Game");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}

		else if (currentMenu == Menu.NewGame) {
			loadListLock = false;
			GUILayout.Box("Name Your Traveller");
			GUILayout.Space(10);
			GUILayout.Label("Name");
			newPlayerName = GUILayout.TextField(newPlayerName, 20);

			if(GUILayout.Button("Save")) {
				if(GUILayout.Button("1")) {
					GlobalController.Instance.NewSave (newGameStartScene, newPlayerName, newGameStartPosX, newGameStartPosY, newGameStartPosZ, 1);
					GlobalController.Instance.globalsActiveSave.save = 3;
					UnityEngine.SceneManagement.SceneManager.LoadScene("1");
				}
				if(GUILayout.Button("2")) {
					GlobalController.Instance.NewSave (newGameStartScene, newPlayerName, newGameStartPosX, newGameStartPosY, newGameStartPosZ, 2);
					GlobalController.Instance.globalsActiveSave.save = 3;
					UnityEngine.SceneManagement.SceneManager.LoadScene("1");
				}
				if(GUILayout.Button("3")) {
					GlobalController.Instance.NewSave (newGameStartScene, newPlayerName, newGameStartPosX, newGameStartPosY, newGameStartPosZ, 3);
					GlobalController.Instance.globalsActiveSave.save = 3;
					UnityEngine.SceneManagement.SceneManager.LoadScene("1");
				}
				//GlobalController.Instance.NewSave (newGameStartScene, newPlayerName, newGameStartPosX, newGameStartPosY, newGameStartPosZ);
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}	
		}

		else if (currentMenu == Menu.Continue) { //This menu handles the save file list and passes the selected save to the GlobalController

			GUILayout.Space(10);
			if(GUILayout.Button("Scan")) {
				scanDirectoryForSaves();
			}
  
			GUILayout.BeginArea (new Rect (25, 50, Screen.width - 50, Screen.height - 100));  
			this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, GUILayout.Width(Screen.width - 50), GUILayout.Height(Screen.height - 100));  
			GUILayout.TextArea(this.dirOutputString);  
			GUILayout.EndScrollView();    
			GUILayout.EndArea();  
			GUI.Label(new Rect(25, Screen.height - 40, 250, 30), "Input a file number:");  
			this.fileNumberString = GUI.TextField(new Rect(140, Screen.height - 40, 60, 30), this.fileNumberString, 5);  
		 
			if(GUI.Button(new Rect(210, Screen.height - 40, 150, 30), "Select file")) {   
				int fileIndex = int.Parse(this.fileNumberString);
				GlobalController.Instance.Load(this.directoryPath + "/" + this.fileNames[fileIndex]); //Passes selected save to the GlobalController Load() function
				GlobalController.Instance.IsSceneBeingLoaded = true;
				int whatScene = GlobalController.Instance.LocalCopyOfData.SceneID;
				SceneManager.LoadScene (whatScene);
			}  
					
			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	void scanDirectoryForSaves() { //This function needs to exist outside of OnGUI because we don't want these calculations happening every frame alongside every GUI element refresh
		if (!Directory.Exists(Application.persistentDataPath + "/Saves")) {
			Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
		}

		this.dirOutputString = ""; //Reset text at beginning of scan because we don't want to repeat saves

		this.directoryPath = Application.persistentDataPath + "/Saves/";   
		this.fileNames = new List<string>( Directory.GetFiles(this.directoryPath, "*.gd")); //only adds files to list that have .gd extensions   

		for (int i = 0; i < this.fileNames.Count; i++) {  
			this.fileNames[i] = Path.GetFileName( this.fileNames[i]); //Removes filepath from the i index in the list 
			this.dirOutputString += i.ToString("D5") + "\t-\t" + this.fileNames[i] + "\n"; //Append each filename into a string
		}
	}
}