using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System;
// Not sure if the following include will enable use of JSON serialization, yet.
using System.Runtime.Serialization;
//using System.Web.Script.Serialization;

public class PortScan : MonoBehaviour {
	// Identify the InputField we'll use for the address input
	public InputField myInputField;
	// Identify the submission event for the input field
	InputField.SubmitEvent se;
	// string myAddress;
	public string hostIP;
	// Define Starting and ending port numbers for port scan
	public int startP = 1;
	public int highP = 1024;

	// ---- HERE WE WORK WITH GLOBAL VARS, via GameManager
	// Default starting Output text string
	public string newText = "";
	// We declare currentText as the contents of what the Game Manager has stored.
	// This way we don't destroy existing information, the first time we use this script.
	public string currentText = "";
	public Text myTextHistory;

	// Use this for initialization
	void Start () {
		currentText = myTextHistory.text;
		// ----------- PortScan FUNCTIONS --------
		// Let's relate myInputField to the actual InputField component in the game.
		// First, let's get the submission event on our InputField set up, and listening
		se = new InputField.SubmitEvent();
		se.AddListener(SubmitInput);
		myInputField.onEndEdit = se;
		// ------------------------------------
	}

	public void SubmitInput(string arg0)
	{
		// Here we'll start the Ping Coroutine
		// ----------- PortScan FUNCTIONS --------
		//UnityEngine.Debug.Log ("Input received: " + arg0);
		// Send the user input to the StartScan function, as a coroutine.
		StartCoroutine(StartScan(arg0));
		// ------------------------------------
		// Clear the input field of text, to keep things tidy.
		myInputField.text = null;
	}

	public IEnumerator StartScan(string arg0)
	{
		// This is the StartScan coroutine, with a 1 second pause.
		// The defined IP address for the prot scan is the input from the user.
		IPAddress hostIP = IPAddress.Parse(arg0);
		newText = ("Performing portscan against: " + arg0 + "\n");
		myTextHistory.text = myTextHistory.text + newText;

		for(int currentPort = startP; currentPort <= highP; currentPort++)
		{
			TcpClient tcpScanner = new TcpClient();

			try {
				tcpScanner.SendTimeout = 300;
				tcpScanner.ReceiveTimeout = 300;
				tcpScanner.Connect(hostIP, currentPort);

				if(tcpScanner.Connected)
				{ 
					UnityEngine.Debug.Log (currentPort);
					newText = ("  - Port " + currentPort + " is open.\n");
					myTextHistory.text = myTextHistory.text + newText;
				} else { 
					//Console.WriteLine("PORT {0} IS CLOSED", currentPort); 
				}
			}

			catch (Exception ex) {
				UnityEngine.Debug.Log ("Port " + currentPort + " threw the following exception: \n" + ex);
			}

			yield return 0;
			tcpScanner.Close();
		}		
		newText = ("Portscan complete.\n---------------------------------------\n");
		myTextHistory.text = myTextHistory.text + newText;
	}
}
