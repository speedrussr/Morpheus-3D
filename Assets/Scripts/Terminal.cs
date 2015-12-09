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
	public CharacterController cc;

	void Awake() {
		cc.enabled = true;
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
		myCamera.enabled = false;
		canvas.enabled = false;
		// Create the Character Controller relationship, so we can enable/disable
		cc = GameObject.Find ("Player").GetComponent<CharacterController> ();
		cc.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Allow interaction with the terminal pop up and input box.
		// Look for the mouse button to be pressed.
		if (Input.GetMouseButtonDown (0)) {
			// If the terminal console is marked as active, and a user clicks, then close the terminal
			// And the global variable is marked as INACTIVE
			if (GameManager.instance.consoleActive == true) {
				GameManager.instance.consoleActive = false;
				if(GameManager.instance.lockCharController == false) {
					cc.enabled = true;
					myCamera.enabled = false;
				}
			} else {
				// If the terminal console is NOT active, and a user clicks, the terminal is opened.
				// And the global variable is marked as ACTIVE.
				Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 3.0f);
				// TODO: Getting a weird error here, when clicking elsewhere in the game. Check logic.
				// Check about using E key to USE the terminal, when close enough to trigger ray
				if (hit.transform.gameObject.tag == "Terminal") {
					GameManager.instance.lockCharController = true;
					if(GameManager.instance.lockCharController == true) {
						cc.enabled = false;
					}
					GameManager.instance.consoleActive = true;
					myCamera.enabled = true;
					canvas.enabled = true;
					// TODO: Consider moving the destroy NetMgrHUD to main canvas, so it can be closed immediately upon start, by player.
					NetworkManager.DestroyObject(NetworkManagerHUD);

				}
			}
		}
	}

}
