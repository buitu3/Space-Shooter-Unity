using UnityEngine;
using System.Collections;

public class DestroyBoltByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other){
		if ((other.tag == "Player") || (other.tag == "Boss"))
		{
			return;
		}
		Destroy(other.gameObject);
	}
}
