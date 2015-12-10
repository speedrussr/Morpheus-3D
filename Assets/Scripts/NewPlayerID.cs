using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewPlayerID : MonoBehaviour {

	// Drag in NewPlayerID script, to access the functions there
	private NewPlayerID myNewPlayerID;
	
	private string tempname;
	private string mytempname;

	// Input field for Name Entry Field, in Main Menu (not active)
	public Text NameInputField = null;

	public int numPlayers;
	public string myNewPlayer;
	//private int playerNumber;
	public Text updateStatus;
	
	void Start () {
		//NameInputField = GameObject.Find ("Main GUI Overlay.Menu Panel.Name Panel.NameInputField").GetComponent<Text> ();
		//updateStatus = GameObject.Find ("Main GUI Overlay.Status Panel").GetComponent<Text> ();
		myNewPlayer = GameManager.instance.tempname;
		gameObject.name = myNewPlayer;
		//Debug.Log ("myNewPlayer = " + myNewPlayer);
		GameManager.instance.AddPlayer(myNewPlayer);
		GameManager.instance.numPlayers += 1;
		Debug.Log ("Player " + myNewPlayer + " has joined the game.");
		// Now let's disable the panel for entering a new username

		//TODO: How can I get this to load as soon as a prefab character is added?!
		//updateStatus.text = updateStatus.text + "Player " + myNewPlayer + " has joined the game.";
	}

	void OnDisconnectedFromServer() {
		Debug.Log ("Player " + myNewPlayer + " has disconnected.");
		Destroy (gameObject);
		// TODO: The following line won't do what you think it will!
		// Locate the user player in the array, by name, and empty that index
		// So it can be reused when a new player logs in.
		GameManager.instance.numPlayers -= 1;
	}

	public void OnClickName() {
		mytempname = NameInputField.text;
		Debug.Log(mytempname);
		GameManager.instance.tempname = mytempname;
		gameObject.name = tempname;
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
}
