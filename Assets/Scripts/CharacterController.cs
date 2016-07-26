using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CharacterController : NetworkBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float rotateVel = 100;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation
	{
		get { return targetRotation; }
	}


	void Start () {
		targetRotation = transform.rotation;
		if(GetComponent<Rigidbody>())
			rBody = GetComponent<Rigidbody> ();
		else {
			Debug.LogError ("The character needs a rigidbody.");
		}
		forwardInput = turnInput = 0;
	}

	void GetInput() {
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}

	void Update () {
		if (isLocalPlayer) {
			GetInput ();
			Turn ();
		}
	}

	void FixedUpdate() {
		Run ();
	}

	void Run () {
		if (Mathf.Abs(forwardInput) > inputDelay) {
			//move
			rBody.velocity = transform.forward * forwardInput * forwardVel;
		} else 
			//zero velocity
			rBody.velocity = Vector3.zero;
	}

	void Turn() {
		if (Mathf.Abs (turnInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		} 
		transform.rotation = targetRotation;
	}
}
