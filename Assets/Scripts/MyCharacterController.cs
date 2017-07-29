using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[DisallowMultipleComponent]
public class MyCharacterController : NetworkBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVel = 40;
	public float rotateVel = 100;

	Animator anim;

	Quaternion targetRotation;
	//Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation
	{
		get { return targetRotation; }
	}

	void Awake() {
		anim = GetComponent<Animator> ();
	}

	void Start () {
		targetRotation = transform.rotation;
//		if(GetComponent<Rigidbody>())
//			rBody = GetComponent<Rigidbody> ();
//		else {
//			Debug.LogError ("The character needs a rigidbody.");
//		}
		// Set all input levels to 0, to start off
		forwardInput = turnInput = 0;
	}

	void GetInput() {
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
		anim.SetFloat("Forward", Input.GetAxis("Vertical"));
	}

	void Update () {
		if (isLocalPlayer) {
			if (Input.GetButtonDown ("Vertical")) {
				Move ();
			}
			if (Input.GetKey (KeyCode.Space)) {
				Jump ();
			}
			GetInput ();
			Turn ();
		}
	}

	void Jump() {
		anim.SetFloat ("Jump", Input.GetAxis ("Vertical"));
	}

	void Move()
	{
			anim.SetFloat ("Forward", Input.GetAxis ("Vertical"));
	}

	void Turn() {
		if (Mathf.Abs (turnInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		} 
		transform.rotation = targetRotation;
	}
}
