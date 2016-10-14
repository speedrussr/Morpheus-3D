using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ChatFunctions : MonoBehaviour {

	[SerializeField] ContentSizeFitter contentSizeFitter;
	[SerializeField] Text showHideButtonText;
	//[SerializeField] Text inputText;
	[SerializeField] Transform messageParentPanel;
	[SerializeField] GameObject newMessagePrefab;

	bool isChatShowing = false;
	//string message = "";
	public List<string> chatHistory = new List<string>();
	private string currentMessage = string.Empty;


	void Start () {
		ToggleChat ();
	}

	public void ToggleChat() {
		isChatShowing = !isChatShowing;
		if (isChatShowing) {
			contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
			showHideButtonText.text = "Hide Chat";
		} else {
			contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.MinSize;
			showHideButtonText.text = "Show Chat";
		}
	}

	public void SetMessage (string message) {
		this.currentMessage = message;
	}

	public void ShowMessage () {
		// Don't send if empty string
		if (currentMessage != "") {
			GameObject clone = (GameObject)Instantiate (newMessagePrefab);
			clone.transform.SetParent (messageParentPanel);
			clone.transform.SetSiblingIndex (messageParentPanel.childCount - 2);
			clone.GetComponent<MessageFunctions> ().ShowMessage (currentMessage);
		}
	}

	[RPC]
	public void ChatMessage(string message) {
		chatHistory.Add (message);
	}
}
