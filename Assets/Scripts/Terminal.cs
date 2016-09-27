using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
//using NewPlayerID;

public class Terminal : MonoBehaviour {
	private RaycastHit hit;
	public Canvas canvas;
	public GameObject NetworkManagerHUD;
	string myPlayerName;
	public Camera myCamera;
	// Create a variable to hold the player name used by the player
	//GameObject myPlayer;
	// Variable to identify current Character Controller. 
	//public CharacterController cc;
	public bool inTerminal = false;

	// Use this for initialization
	void Start () {
		//cc = GetComponent<CharacterController> ();
		myCamera.enabled = false;
		canvas.enabled = false;
		// Create the Character Controller relationship, so we can enable/disable
		//cc = GameObject.Find ("Player").GetComponent<CharacterController> ();
		//cc.enabled = true;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.BackQuote)) {
			if (inTerminal == false) {
				myCamera.enabled = true;
				canvas.enabled = true;
				inTerminal = true;
				//cc.enabled = false;
			} else {
				myCamera.enabled = false;
				canvas.enabled = false;
				inTerminal = false;
				//cc.enabled = true;
			}
		}

	}

}
