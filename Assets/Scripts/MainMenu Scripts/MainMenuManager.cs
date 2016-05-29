using UnityEngine;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

	public enum Menu {
		MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;

	void OnGUI () {
		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.MainMenu) {
			GUILayout.Box("2D Aventure Game");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				Game.current = new Game();
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				SaveLoad.Load();
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}

		else if (currentMenu == Menu.NewGame) {
			GUILayout.Box("Name Your Traveller");
			GUILayout.Space(10);
			GUILayout.Label("Name");
			Game.current.traveller.name = GUILayout.TextField(Game.current.traveller.name, 20);

			if(GUILayout.Button("Save")) {
				SaveLoad.Save(); //Save the current Game as a new saved Game
				UnityEngine.SceneManagement.SceneManager.LoadScene("1"); //Load Scene 1
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
		}

		else if (currentMenu == Menu.Continue) {
			GUILayout.Box("Select Save File");
			GUILayout.Space(10);

			foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(g.traveller.name + " - ")) {
					Game.current = g;
					UnityEngine.SceneManagement.SceneManager.LoadScene(1);
				}
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
}