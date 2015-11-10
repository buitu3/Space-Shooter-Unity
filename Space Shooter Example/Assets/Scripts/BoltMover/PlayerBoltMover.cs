using UnityEngine;
using System.Collections;

public class PlayerBoltMover : MonoBehaviour {

	public float speed;

    private Rigidbody boltRigidBody;

    void Awake()
    {
        boltRigidBody = GetComponent<Rigidbody>();
    }

	void Start () {
        boltRigidBody.velocity = this.transform.forward * speed;
	}
}
