using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstantiateNetwork : MonoBehaviour {

	public TextMesh hostname;
	public int trackNetArrayIndex = 0;
	// Define instantiation array for network components. Locations are defined by the location
	// of empty game objects, defined manually in the Event Manager. See Inspector.
	public Transform[] netEntitySpawnLocations;
	public GameObject myNetEntityToSpawn;
	public GameObject myNetEntityToClone;

	public void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instantiateEntity(string ipaddress) {
		// Code to instantiate each ipaddress as a physical 3D object in the game world
		myNetEntityToClone = Instantiate(myNetEntityToSpawn, netEntitySpawnLocations [trackNetArrayIndex].transform.position, Quaternion.Euler (0, 0, 0)) as GameObject; 
		//--------------------------
		//Insert the empty game object with the TextMesh attached
		hostname = myNetEntityToClone.GetComponentInChildren<TextMesh> () as TextMesh;
		hostname.text = ipaddress;
		//--------------------------
		// Rename each clone to the ipaddress of the entity.
		myNetEntityToClone.name = ipaddress;
		trackNetArrayIndex++;
	}
}
