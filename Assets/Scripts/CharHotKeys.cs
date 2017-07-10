using UnityEngine;
using System.Collections;

public class CharHotKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey (KeyCode.N)) {
			gameObject.transform.position = new Vector3 (-160, 10, -5);
		} else if (Input.GetKey (KeyCode.H)) {
			gameObject.transform.position = new Vector3 (0, 1, 0);
		}
	}
}
