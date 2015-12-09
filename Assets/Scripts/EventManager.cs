using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Serialization;

public class EventManager : MonoBehaviour {

	// Drag in NewPlayerID script, to access the functions there
	private NewPlayerID myNewPlayerID;

	private string tempname;
	private string mytempname;
	public Text inputField = null;
	public Text NameInputField = null;
	public Camera myCamera;
	public Canvas canvas;
	// Define Menu gameobjects so we can show/hide the Main Menu
	public GameObject menu;
	private bool MenuShown = false;
	// Define the statusMenu, so we can show/hide it
	public GameObject statusPanel;
	private bool StatusShown = false;
	// Define the network HUD, so we can show/hide it
	public GameObject networkHUD;
	private bool hudShown = false;
	// Define audioSource, so we can enable/disable
	public GameObject audioSource;
	private bool audioOn = false;
	// Create reference to players[] so we can associate it to GameManager
	public string[] players;
	
	void Start() {
		inputField = GameObject.Find ("Canvas.InputField").GetComponent<Text> ();
		NameInputField = GameObject.Find ("Menu Panel.NameInputField").GetComponent<Text> ();
	}

	// This is used from the Start Scene - (trying to get rid of this)
	public void OnClick() {
		tempname = inputField.text;
		GameManager.instance.tempname = tempname;
		Application.LoadLevel("Main");
	}

	public void OnClickName() {
		mytempname = NameInputField.text;
		Debug.Log(mytempname);
		GameManager.instance.tempname = mytempname;
		// Let's find the first empty index in the players[]
		//int myIndex;
		//int myPlayerNumber;
		//for (myIndex = 0; myIndex <= GameManager.players.Length - 1; myIndex++) {
		//	if (GameManager.players[myIndex] == mytempname) {
		//		myPlayerNumber = myIndex;
		//		Debug.Log("My player exists. My player number is: " + myIndex);
		//	} else if(GameManager.players[myIndex] == null) {
		//		myIndex = myIndex - 1;
		//		Debug.Log("My player does not exist. My new player number is: " + myIndex);
		//	}
		//}
	}

	public void QuitApp() {
		Application.Quit ();
	}

	public void RestoreGame() {
		canvas.enabled = false;
		myCamera.enabled = false;
		GameManager.instance.lockCharController = false;
	}

	public void GoMain() {
		Application.LoadLevel ("Main");
	}

	public void menuShow() {
		MenuShown = !MenuShown;
		menu.SetActive (MenuShown);
	}

	public void StatusShow() {
		StatusShown = !StatusShown;
		statusPanel.SetActive (StatusShown);
	}

	public void audioToggle() {
		audioOn = !audioOn;
		audioSource.SetActive (audioOn);
	}

}
