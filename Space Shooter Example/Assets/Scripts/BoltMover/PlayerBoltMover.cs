using UnityEngine;
using System.Collections;

public class PlayerBoltMover : MonoBehaviour {

	public float speed;

	void Start () {
		rigidbody.velocity = this.transform.forward * speed;
	}
}
