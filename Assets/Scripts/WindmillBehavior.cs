using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillBehavior : MonoBehaviour {

	// Define the first windmill, so we can have it turn, as needed.
	public float spinx;
	public float spiny;
	public float spinz;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(spinx, spiny, spinz, Space.World);
	}
}
