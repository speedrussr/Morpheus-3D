using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Diagnostics;

public class MyWhois : MonoBehaviour {
	
	// Identify the InputField we'll use for the address input
	public InputField myInputField;
	// Identify the submission event for the input field
	InputField.SubmitEvent se;
	// string myAddress;
	public string myDomain;
	// Default starting Output text string
	public string newText = "";
	// We declare currentText as the contents of what the Game Manager has stored.
	// This way we don't destroy existing information, the first time we use this script.
	public string currentText = "";
	public Text myTextHistory;

	// Next we configure our server information. The record type and server can be changed to match your needs.
	private const int Whois_Server_Default_PortNumber = 43;
	private const string Domain_Record_Type = "domain";
	private const string Whois_Server = "whois.internic.net";

	void Start () {
		// Take value of the gamemanager's output, and make that our current text, for this script.
		currentText = myTextHistory.text;
		// ----------- WHOIS FUNCTIONS --------
		// First, let's get the submission event on our InputField set up, and listening
		se = new InputField.SubmitEvent();
		se.AddListener(SubmitInput);
		myInputField.onEndEdit = se;
		// ------------------------------------
	}

	public void SubmitInput(string arg0)
	{
		// Here we'll start the whois Coroutine
		// ----------- WHOIS FUNCTIONS --------
		//UnityEngine.Debug.Log ("Input received: " + arg0);
		// Add comment to output explaining what the request was for.
		newText = ("Whois request for " + arg0 + "\n-  -  -  -  -  -  -  -  -  -  -  -  -  -\n");
		// Add that comment to the gamemanager's output values, so it's not lost when other scripts are run.
		myTextHistory.text = myTextHistory.text + newText;
		// Start the domain whois lookup function, using the argument provided by the user.
		StartCoroutine(Lookup(arg0));
		// ------------------------------------
		// Clear the input field of text, to keep things tidy.
		myInputField.text = null;
	}

	IEnumerator Lookup(string domainName)
		{
			// Create a new TcpClient, and call it whoisClient, for this script iteration.
			using (TcpClient whoisClient = new TcpClient())
			{
				// Use Connect method to connect to the server information provided above.
				whoisClient.Connect(Whois_Server, Whois_Server_Default_PortNumber);
				// Create our query string.
				string domainQuery = Domain_Record_Type + " " + domainName + "\r\n";
				// Turn our query string into a byte array that we can stream to the server.
				byte[] domainQueryBytes = Encoding.ASCII.GetBytes(domainQuery.ToCharArray());
				// Create the whois stream attached to our client, so we can communicate.
				Stream whoisStream = whoisClient.GetStream();
				// Write our query (which is now a character array) to our new whois stream (to the server).
				whoisStream.Write(domainQueryBytes, 0, domainQueryBytes.Length);
				// Create our stream reader, encoded in ASCII, so we can get our response back.
				StreamReader whoisStreamReader = new StreamReader(whoisClient.GetStream(), Encoding.ASCII);
				// Create a string variable to hold our response content.
				string streamOutputContent = "";
				// Create a new list, called whoisData, that we'll use to store the response, as strings.
				List<string> whoisData = new List<string>();
				// While we still have response data coming, use the stream reader
				while (null != (streamOutputContent = whoisStreamReader.ReadLine()))
				{
					// Add each line to our list.
					whoisData.Add(streamOutputContent);
				}
				// Once the stream has completed, we close the TCPClient we created.
				whoisClient.Close();
				// Wait 2 seconds. This is for testing, to ensure we don't lose data.
				yield return new WaitForSeconds (2.0f);
				// Loop through our whois list, and dump each string to our globally stored ouput, with a newline.
				for (int i = 0; i < whoisData.Count; i++) {
				newText = (whoisData[i] + "\n");
				myTextHistory.text = myTextHistory.text + newText;
				}
			}
		}        
	}
