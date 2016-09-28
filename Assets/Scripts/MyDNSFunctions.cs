using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System.Net;

public class MyDNSFunctions : MonoBehaviour {
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

	void Start () {
		currentText = myTextHistory.text;
		// ----------- NSLOOKUP FUNCTIONS --------
		// Let's relate myInputField to the actual InputField component in the game.
		//myInputField = GameObject.Find("DNSInput").GetComponent<InputField>();
		// First, let's get the submission event on our InputField set up, and listening
		se = new InputField.SubmitEvent();
		se.AddListener(SubmitInput);
		myInputField.onEndEdit = se;
		// ------------------------------------
	}

	public void SubmitInput(string arg0)
	{
		// Here we'll start the nslookup Coroutine
		// ----------- NSLOOKUP FUNCTIONS --------
		UnityEngine.Debug.Log ("Input received: " + arg0);
		newText = ("DNS resolution request for " + arg0 +".\n");
		myTextHistory.text = myTextHistory.text + newText;
		StartCoroutine(StartLookup(arg0));
		// ------------------------------------
		// Clear the input field of text, to keep things tidy.
		myInputField.text = null;
	}

	IEnumerator StartLookup (string arg0)
	{
		// Create a new host entity, called host.
		IPHostEntry host;
		// Assign the response of our DNS resolution (using the user provided domain name) to the host variable.
		host = Dns.GetHostEntry (arg0);
		// Wait 2 seconds.  This is for dev purposes, to ensure we're not stomping on ourselves.
		yield return new WaitForSeconds (2.0f);
		//UnityEngine.Debug.Log ("Entered StartLookup Function..." + arg0);
		//UnityEngine.Debug.Log ("GetHostEntry({0}) returns: " + arg0);
		// For each ip returned, save it to global output value, and display on the screen.
		foreach (IPAddress ip in host.AddressList) {
			newText = ("            " + ip + "\n---------------------------------------------\n");
			myTextHistory.text = myTextHistory.text + newText;
		}
	}
		
}

