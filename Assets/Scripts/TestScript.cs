using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;

public class TestScript : MonoBehaviour {
	// Define the input field, so we can enter commands
	InputField input;
	InputField.SubmitEvent se;
	// Define the output variable
	public Text output;
	// This is the string we'll update and send to the statusPanel
	public Text statusText;

	// Use this for initialization
	void Start () {
		input = gameObject.GetComponent<InputField> ();
		se = new InputField.SubmitEvent();
		se.AddListener(SubmitInput);
		input.onEndEdit = se;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SubmitInput(string arg0)
	{
		// The following two lines are used for chat windows, to concatenate all the text from 
		// the chat window, so it's all included on the next refresh. i.e. we don't lose part
		// of the conversation.
		//string currentText = output.text;
		//string newText = currentText + "\n" + arg0;

		// Set up a command string that is displayed in the terminal window, as user feedback. 
		// Capture null input so we don't inadvertently run nmap with no options.
		if (arg0.Length < 4) {
			string commandText = "(command): NULL ";
			output.text = commandText;
			//UnityEngine.Debug.Log("Null input received");
		} else {
			// The below code identifies the player's name
			//output.text = GameObject.FindGameObjectWithTag ("Player").name;
			string commandText = "(command): nmap " + arg0;
			statusText.text = ("nmap " + commandText);
			UnityEngine.Debug.Log ("Valid input received");
			UnityEngine.Debug.Log ("Execution Path: " + Application.dataPath);
			UnityEngine.Debug.Log (arg0);
			Process.Start ("./russ-nmap.sh", arg0);
			input.text = "";
			input.ActivateInputField ();
		}
	}
}
