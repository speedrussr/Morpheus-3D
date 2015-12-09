using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Serialization;

public class EventManager : MonoBehaviour {

	// Drag in NewPlayerID script, to access the functions there
	private NewPlayerID myNewPlayerID;

	private string tempname;
	private string mytempname;
	// Input field for Wall Terminal
	public Text inputField = null;
	// Input field for Name Entry Field, in Main Menu (not active)
	public Text NameInputField = null;
	// Input field for Chat Dialog
	public Text chatInputField = null;
	public Camera myCamera;
	public Canvas canvas;
	// Define Menu gameobjects so we can show/hide the Main Menu
	public GameObject menu;
	public bool MenuShown = true;
	// Define the statusMenu, so we can show/hide it
	public GameObject statusPanel;
	public bool StatusShown = true;
	// Define the chatMenu, so we can show/hide it
	public GameObject chatPanel;
	public bool ChatShown = true;
	// Define the network HUD, so we can show/hide it
	public GameObject networkHUD;
	public bool hudShown = true;
	// Define audioSource, so we can enable/disable
	public GameObject audioSource;
	private bool audioOn = true;
	// Create reference to players[] so we can associate it to GameManager
	public string[] players;
	
	void Start() {
		inputField = GameObject.Find ("Canvas.InputField").GetComponent<Text> ();
		NameInputField = GameObject.Find ("Menu Panel.NameInputField").GetComponent<Text> ();
		chatInputField = GameObject.Find ("Chat Panel.chatInputField").GetComponent<Text> ();
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

	public void ChatShow() {
		ChatShown = !ChatShown;
		chatPanel.SetActive (ChatShown);
	}
}
