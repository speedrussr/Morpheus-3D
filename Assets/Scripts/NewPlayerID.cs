using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NewPlayerID : MonoBehaviour {

	public int numPlayers;
	public string myNewPlayer;
	//private int playerNumber;
	public Text updateStatus;
	
	void Start () {
		myNewPlayer = GameManager.instance.tempname;
		gameObject.name = myNewPlayer;
		Debug.Log ("myNewPlayer = " + myNewPlayer);
		GameManager.instance.AddPlayer(myNewPlayer);
		GameManager.instance.numPlayers += 1;
		Debug.Log ("Player " + myNewPlayer + " has joined the game.");
		//TODO: How can I get this to load as soon as a prefab character is added?!
		//updateStatus = GameObject.Find("Status Panel").GetComponent<Text>();
		updateStatus.text = updateStatus.text + "Player " + myNewPlayer + " has joined the game.";
	}

	void OnDisconnectedFromServer() {
		Debug.Log ("Player " + myNewPlayer + " has disconnected.");
		Destroy (gameObject);
		GameManager.instance.numPlayers -= 1;
	}

//	public void changeMyName() {
//		int myIndex;
//		for(myIndex = 0; myIndex
//		//gameObject.name == myNewPlayer;
//	}
	
}
