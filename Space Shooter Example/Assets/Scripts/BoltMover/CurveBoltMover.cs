using UnityEngine;
using System.Collections;

public class CurveBoltMover : MonoBehaviour {
	public float speed;
	public float rotateSpeed;
	// Use this for initialization
	void Start () {
//		rigidbody.velocity = transform.forward * speed;
		rigidbody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
	}

	void FixedUpdate () {
		rigidbody.velocity = transform.forward * speed;
//		rigidbody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
	}
}
