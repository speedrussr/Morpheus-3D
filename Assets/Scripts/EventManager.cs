using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
using System;
using System.Diagnostics;

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
	// Define text component of statusPanel
	public Text statusPanelText;
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
	// Reference to Terminal Output, so we can clear it.
	public Text terminalOutput;
	// Public var to define status icon in the Inspector
	public Image NetConnStatusPanel;
	// Default starting Output text string
	public string newText = "";
	// We declare currentText as the contents of what the Game Manager has stored.
	// This way we don't destroy existing information, the first time we use this script.
	public string currentText = "";
	// Variable for output window in terminal
	public Text myTextHistory;

	void Update () {
		// Function to check network status and change indicator in UI, and set GameManager bool
		CheckNetwork();
	}

	void Start() {
//		inputField = GameObject.Find ("Canvas.InputField").GetComponent<Text> ();
//		chatInputField = GameObject.Find ("Chat Panel.chatInputField").GetComponent<Text> ();
//		statusPanelText = GameObject.Find ("Status Panel").GetComponent<Text>();
		currentText = myTextHistory.text;
	}

	// This is used from the Start Scene - (trying to get rid of this)
	public void OnClick() {
		tempname = NameInputField.text;
		GameManager.instance.tempname = tempname;
		Application.LoadLevel("Main");
		GameManager.instance.nameSelected = true;
		statusPanelText.text = statusPanelText.text + ("Player " + tempname + " has logged on.");
	}

	public void CheckNetwork() {
		//   Returns "true" if a network connection is available; otherwise, "false".
		if (IsNetworkAvailable()) {
			// Network connection is available - Set NetConnStatus to TRUE
			//Debug.Log("Network is active.");
			GameManager.instance.netConnStatus = true;
			NetConnStatusPanel.color = UnityEngine.Color.green;
		} else {
			// Network connection is unavailable - Set NetConnStatus to FALSE
			//Debug.Log("Network is inactive.");
			GameManager.instance.netConnStatus = false;
			NetConnStatusPanel.color = UnityEngine.Color.red;
		}
	}
		
	public static bool IsNetworkAvailable()
	//public static bool IsNetworkAvailable(long minimumSpeed)
		{
		// Check network connection, bypassing virtual and loopback interfaces
		if (!NetworkInterface.GetIsNetworkAvailable()) {
			return false;
		}

			foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
			{
				// discard because of standard reasons
				if ((ni.OperationalStatus != OperationalStatus.Up) ||
					(ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
					(ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
					continue;

				// this allow to filter modems, serial, etc.
				// I use 10000000 as a minimum speed for most cases
				//if (ni.Speed < minimumSpeed)
				//	continue;

				// discard virtual cards (virtual box, virtual pc, etc.)
				if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
					(ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
					continue;

				// discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
				if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
					continue;
				return true;
			}
			return false;
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

	public void ClearTerminal() {
		terminalOutput.text = "";
	}

	public void GoNet() {
		transform.position = new Vector3 (-140, 10, 0);
	}

	public void GoHome() {
		transform.position = new Vector3 (0, 10, 0);
	}

	public void MyNetInfo() {
		currentText = myTextHistory.text;
		string localIP = Network.player.ipAddress;
		newText = ("---------------------------------\n" + "Local IP: " + localIP + "\n" + "---------------------------------\n");
		currentText = currentText + newText;
		//GameManager.instance.myGlobalOutputField.text = GameManager.instance.myGlobalOutputField.text + newText;
	}
}
