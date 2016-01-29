using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.UI;

public class Chat : MonoBehaviour {

	// General variables declaring the List and individual messages
	public List<string> chatHistory = new List<string>();
	private string currentMessage = string.Empty;
	public Text chatBox;

	// Define the input field, so we can enter commands
	InputField input;
	InputField.SubmitEvent se;
	// Define the output variable
	public Text output;
	// This is the string we'll update and send to the statusPanel
	public Text statusText;

	public void Start() {
		// TODO: Define input field so we can use it to assign currentMessage

	}

//	private void goChat() {
//		if (!string.IsNullOrEmpty(currentMessage.Trim())) {
//			GetComponent<NetworkView>().RPC("ChatMessage", RPCMode.AllBuffered, new object[] {currentMessage});
//			currentMessage = string.Empty;
//
//			input = gameObject.GetComponent<InputField> ();
//			se = new InputField.SubmitEvent();
//			se.AddListener(chatHistory);
//			input.onEndEdit = se;
//		}
//
//		foreach (string message in chatHistory) {
//			chatBox.text = chatBox.text + message;
//		}
//	}
//
//	[RPC]
//	public void ChatMessage(string message) {
//		chatHistory.Add (message);
//	}
}
