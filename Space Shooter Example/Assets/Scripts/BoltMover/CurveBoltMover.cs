using UnityEngine;
using System.Collections;

public class CurveBoltMover : MonoBehaviour {
	public float speed;
	public float rotateSpeed;

    private Rigidbody boltRigidBody;

    void Awake()
    {
        boltRigidBody = GetComponent<Rigidbody>();
    }

	void Start () {
//		rigidbody.velocity = transform.forward * speed;
        boltRigidBody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
	}

	void FixedUpdate () {
        boltRigidBody.velocity = transform.forward * speed;
//		rigidbody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
	}
}
