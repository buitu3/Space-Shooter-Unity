using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	/// <summary>
	/// Amount of time between activate and destroy.
	/// </summary>
	public float timeToDestruction;

	//==============================================
	// Getters and Setters
	//==============================================

	//==============================================
	// Unity Methods
	//==============================================

	void Start () {
		Destroy(gameObject,timeToDestruction);
	}

	//==============================================
	// Methods
	//==============================================
}
