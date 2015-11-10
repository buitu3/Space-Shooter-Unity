using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;  // Player limit movement zone
}

[System.Serializable]
public class PlayerBolt
{
	public GameObject straightBolt;
}

public class PlayerController : MonoBehaviour {

    // Create Singleton
    //private static PlayerController _instance;
    public static PlayerController Instance;
        /*
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return _instance;
        }
    }
          */

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	public float speed;		// Player movement speed
	public float fireRate;

	public Boundary boundary;
	public PlayerBolt bolt;
    public MovementTouchPad movementTouchPad;

	public Transform mShotSpawn;

    private Rigidbody playerRigidbody;
    private bool isDead;
    //private float mNextFire;

	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================

    void Awake()
    {
        Instance = this;

        playerRigidbody = GetComponent<Rigidbody>();
        isDead = false;
    }

    void Start()
    {
        //mNextFire = 0.5f;
        
        // Recalculate the size of limit movement zone for different resolution
        int defaultHeight = 800;
        int defaultWidth = 480;
        float defaultRatio = (float)defaultWidth / defaultHeight;
        float screenRatio = (float)Screen.width / Screen.height;
        float resizeRatio = (float)screenRatio / defaultRatio;

        boundary.xMax *= resizeRatio;
        boundary.xMin = -boundary.xMax;
        boundary.zMax *= resizeRatio;
        boundary.zMax *= resizeRatio;
        
        // Start shootting bolts
        StartCoroutine(shootBolt());
    }
	
    /*
	void Update(){
		//if (Input.GetButton ("Fire1") && Time.time > mNextFire) {
		if (Time.time > mNextFire) {
			mNextFire = Time.time + fireRate;
			Instantiate(bolt.straightBolt, mShotSpawn.position, mShotSpawn.rotation);
		}
	}
    */

	void FixedUpdate(){

        // Get input from Keyboard
		float mMoveVertical = Input.GetAxis ("Vertical");
		float mMoveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 mMovement = new Vector3 (mMoveHorizontal, 0.0f, mMoveVertical);
		//rigidbody.velocity = mMovement * speed;

        // Get input from touchPad
        Vector2 touchPadDirection = movementTouchPad.getDirection();
        Vector3 touchPadMovement = new Vector3(touchPadDirection.x, 0.0f, touchPadDirection.y);

        if (mMovement.magnitude != 0)
        {
            // Move by keyboard input
            //mMovement.Normalize();
            playerRigidbody.velocity = mMovement * speed;
        }
        else
        {
            // Move by touchPad input
            playerRigidbody.velocity = touchPadMovement * speed;           
        }

        // Limit player movement inside the screen
        playerRigidbody.position = new Vector3(
                Mathf.Clamp(playerRigidbody.position.x, boundary.xMin, boundary.xMax),
				0.0f,
                Mathf.Clamp(playerRigidbody.position.z, boundary.zMin, boundary.zMax)
		);
		
	}

	//==============================================
	// Methods
	//==============================================

    IEnumerator shootBolt()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            GameObject boltInstance = Instantiate(bolt.straightBolt, mShotSpawn.position, mShotSpawn.rotation) as GameObject;
            boltInstance.transform.SetParent(Instance.transform);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
