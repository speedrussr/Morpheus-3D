using UnityEngine;
using System.Collections;

public class NetEntityAttributes : MonoBehaviour {

	public TextMesh hostname;
	public int trackNetArrayIndex = 0;
	// Define instantiation array for network components. Locations are defined by the location
	// of empty game objects, defined manually in the Event Manager. See Inspector.
	public Transform[] netEntityPortLocations;
	public GameObject myNetEntityPortToSpawn;
	public GameObject myNetEntityPortToClone;
	
	public void instantiateEntityPort(string ipaddress, string portNumber) {
		// Code to instantiate each ipaddress as a physical 3D object in the game world
		myNetEntityPortToClone = Instantiate(myNetEntityPortToSpawn, netEntityPortLocations [trackNetArrayIndex].transform.position, Quaternion.Euler (0, 0, 0)) as GameObject; 
		//--------------------------
		//Insert the empty game object with the TextMesh attached
		hostname = myNetEntityPortToClone.GetComponentInChildren<TextMesh> () as TextMesh;
		hostname.text = ipaddress;
		//--------------------------
		// Rename each clone to the ipaddress of the entity.
		myNetEntityPortToClone.name = ipaddress+portNumber;
		//trackNetArrayIndex++;
	}
}
