using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class MovementBeta : MonoBehaviour {
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		//turning
		//jumping
		Move();
	}

	void Move()
	{
		anim.SetFloat("Forward", Input.GetAxis("Vertical"));

	}
}
