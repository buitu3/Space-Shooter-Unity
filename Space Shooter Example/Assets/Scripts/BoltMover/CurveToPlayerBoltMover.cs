using UnityEngine;
using System.Collections;

public class CurveToPlayerBoltMover : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	///<summary>
	/// Bolt moving speed
	/// </summary>
	public float speed;
	/// <summary>
	/// Bolt rotating speed
	/// </summary>
	public float rotateSpeed;

	private GameObject playerObject;

	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================

    /*
	void Start(){
		playerObject = GameObject.FindWithTag ("Player");
		if (playerObject == null){
			print ("Cannot find Player");
		}
		StartCoroutine(approachPlayer());
	}
    */
    void Awake()
    {
        playerObject = GameObject.FindWithTag("Player");
        if (playerObject == null)
        {
            print("Cannot find Player");
        }
        StartCoroutine(approachPlayer());
    }
	/*
	void Update () {
		rigidbody.velocity = transform.forward * speed;

		if (playerObject != null){
			Vector3 playerDir = playerObject.transform.position - transform.position;
			playerDir = transform.InverseTransformVector(playerDir);

			float dx = playerDir.x;
			float dz = playerDir.z;
			//float angle =  Mathf.Atan (dx/Mathf.Abs(dz)) * Mathf.Rad2Deg;
			// Get the Angle between boltfoward and Player's Direction
			float angle =  Mathf.Atan (dx/dz) * Mathf.Rad2Deg;
			if (angle < 0 && dx > 0){
				angle += 180;
			}
			if (angle > 0 && dx < 0){
				angle -= 180;
			}

			// Gradually rotate bolt to player's direction

			if (Mathf.Abs(angle) >= rotateSpeed){
				if (angle < 0){
					rigidbody.angularVelocity = (new Vector3(0, -rotateSpeed, 0));
				}
				if (angle > 0){
					rigidbody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
				}
			}else if (Mathf.Abs(angle) == 0){
				rigidbody.angularVelocity = (new Vector3(0, 0, 0));
			}else if (Mathf.Abs(angle) < rotateSpeed){
				rigidbody.angularVelocity = (new Vector3(0, angle, 0));
			}

//			if (Mathf.Abs(angle) >= rotateSpeed){
//				if (angle < 0){
//					transform.rotation = Quaternion.LookRotation(new Vector3(0, 
//					                                         transform.rotation.y-rotateSpeed, 
//					                                         0));
//				}
//				if (angle > 0){
//					transform.rotation = Quaternion.LookRotation(new Vector3(0, 
//					                                         transform.rotation.y+rotateSpeed, 
//					                                         0));
//				}
//			}else if (Mathf.Abs(angle) == 0){
//				transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0));
//			}else if (Mathf.Abs(angle) < rotateSpeed){
//				transform.rotation = Quaternion.LookRotation(new Vector3(0, 
//				                                         transform.rotation.y+angle, 
//				                                         0));
//			}

//			transform.LookAt (playerObject.transform);

//			print (dx + " : " + dz);
//			print (angle);

		}
	}
	*/


	//==============================================
	// Methods
	//==============================================

	IEnumerator approachPlayer(){
		while (true){
			rigidbody.velocity = transform.forward * speed;
			
			if (playerObject != null){
				Vector3 playerDir = playerObject.transform.position - transform.position;
				playerDir = transform.InverseTransformVector(playerDir);
				
				float dx = playerDir.x;
				float dz = playerDir.z;
				//float angle =  Mathf.Atan (dx/Mathf.Abs(dz)) * Mathf.Rad2Deg;
				// Get the Angle between boltfoward and Player's Direction
				float angle =  Mathf.Atan (dx/dz) * Mathf.Rad2Deg;
				if (angle < 0 && dx > 0){
					angle += 180;
				}
				if (angle > 0 && dx < 0){
					angle -= 180;
				}
				
				// Gradually rotate bolt to player's direction
				
				if (Mathf.Abs(angle) >= rotateSpeed){
					if (angle < 0){
						rigidbody.angularVelocity = (new Vector3(0, -rotateSpeed, 0));
					}
					if (angle > 0){
						rigidbody.angularVelocity = (new Vector3(0, rotateSpeed, 0));
					}
				}else if (Mathf.Abs(angle) == 0){
					rigidbody.angularVelocity = (new Vector3(0, 0, 0));
				}else if (Mathf.Abs(angle) < rotateSpeed){
					rigidbody.angularVelocity = (new Vector3(0, angle, 0));
				}
			}
			yield return new WaitForSeconds(0.3f);
		}
	}
}
