using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class MyNetFunctions : MonoBehaviour {
	// Identify the InputField we'll use for the address input
	public InputField myInputField;
	// Identify the submission event for the input field
	InputField.SubmitEvent se;
	// string myAddress;
	public Ping myPing;
	// Default starting Output text string
	public string newText = "";
	// We declare currentText as the contents of what the Game Manager has stored.
	// This way we don't destroy existing information, the first time we use this script.
	public string currentText = "";
	public Text myTextHistory;

	// Use this for initialization
	void Start () {
		currentText = myTextHistory.text;
		// ----------- PING FUNCTIONS --------
		// Let's relate myInputField to the actual InputField component in the game.
		//myInputField = GameObject.Find("PingInput").GetComponent<InputField>();
		// First, let's get the submission event on our InputField set up, and listening
		se = new InputField.SubmitEvent();
		se.AddListener(SubmitInput);
		myInputField.onEndEdit = se;
		// ------------------------------------
	}

	public void SubmitInput(string arg0)
	{
		// Here we'll start the Ping Coroutine
		// ----------- PING FUNCTIONS --------
		//UnityEngine.Debug.Log ("Input received: " + arg0);
		// Send the user input to the StartPing function, as a coroutine.
		StartCoroutine(StartPing(arg0));
		// ------------------------------------
		// Clear the input field of text, to keep things tidy.
		myInputField.text = null;
	}

	public IEnumerator StartPing(string arg0)
	{
		// This is the Ping coroutine, with a 2 second pause.
		Ping myPing = new Ping (arg0);
		yield return new WaitForSeconds (2.0f);
		// Return the ping time value in MS, minus the 2 seconds we added as a pause.
		// We will save the command and results to the global output value, so it doesn't get lost.
		newText = ("Ping time to " + arg0 + " is: " + ((myPing.time - 2) * 10) + "ms.\n---------------------------------------------\n");
		myTextHistory.text = myTextHistory.text + newText;
	}
}
