using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Public Variables
	// consoleTaken will indicate whether one user is already using a terminal, and allow restricting other players interacting with it
	public bool consoleTaken = false;
	public bool consoleActive = false;
	public static GameManager instance;
	// Track how many user players
	public int numPlayers;
	// Create an array containing the names of user players
	public string[] players;

	// Default name string for users who don't enter a name at start screen
	public string tempname = "John Doe";

	// Start with 0 terminals, increment for naming, as new terminals added
	public int numTerminals = 0;
	// Create variable for tracking single user char controller functionality
	public bool lockCharController = false;
	// Define the statusBlock so we can send text there.
	public Text statusBlock;
	// TESTING
	public string myNewPlayer;
	public Text updateStatus;
	// Has the player selected a name?
	public bool nameSelected = false;
	
	public GameObject myNamePanel;

	// Private Variables
	
	void Awake()
	{
		// Create Singleton
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
		
		DontDestroyOnLoad(gameObject);
		players = new string[8];
	}

	// Use this for initialization
	void Start () {
		numPlayers = 0;
		nameSelected = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (myNamePanel != null) {
			if (nameSelected == true) {
			myNamePanel = GameObject.Find ("Name Panel");
			myNamePanel.SetActive(false);
			}
		}
	}

	// Add a new player name to the array of players
	public void AddPlayer(string name) {
		players[numPlayers] = name;
	}

	// List the players in the game - ignore null entries
	public void ListPlayers() {
		statusBlock = GameObject.Find ("Status Panel").GetComponent<Text> ();
		Debug.Log ("In List Players function");
		foreach(string element in players){
			if(element == null){
				return;
			} else {
				Debug.Log(statusBlock.text + element + "\n");
				statusBlock.text = statusBlock.text + element + "\n";
			}
		}
	}
}
