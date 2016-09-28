using UnityEngine;
using System.Collections;

public class Exo_GrayCharacterController : MonoBehaviour {

	private Animator egAnimator;

	// Use this for initialization
	void Start () {
		egAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// Define forward and backward walking input
		egAnimator.SetFloat ("VSpeed", Input.GetAxis ("Vertical"));
		// Check for running
		if (Input.GetKey (KeyCode.LeftShift) && egAnimator.GetFloat ("VSpeed") > 0f) {
			egAnimator.SetBool ("isRunning", true);
			transform.Translate (Vector3.forward * Time.deltaTime * 10f);
		} else {
			egAnimator.SetBool ("isRunning", false);
		}
			
		// Define jumping input
		if (Input.GetButtonDown ("Jump")) {
			egAnimator.SetBool ("isJumping", true);
			Invoke ("StopJumping", 0.1f);
		}

		// As long as user is pressing a, and we're not moving, turn left
		if(Input.GetKey("a")) {
			// Allow turning and walking
			transform.Rotate(Vector3.down * Time.deltaTime * 100.0f);

			if(Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f) {
				egAnimator.SetBool("TurnLeft", true);
			}
		} else {
			egAnimator.SetBool("TurnLeft", false);
		}

		// As long as user is pressing e, and we're not moving, turn right
		if(Input.GetKey("d")) {
			// Allow turning and walking
			transform.Rotate(Vector3.up * Time.deltaTime * 100.0f);

			if(Input.GetAxis("Vertical") == 0f && Input.GetAxis("Horizontal") == 0f) {
				egAnimator.SetBool("TurnRight", true);
			}
		} else {
			egAnimator.SetBool("TurnRight", false);
		}
	}

	// Function to reverse Jumping bool
	void StopJumping () {
		egAnimator.SetBool ("isJumping", false);
	}
}
