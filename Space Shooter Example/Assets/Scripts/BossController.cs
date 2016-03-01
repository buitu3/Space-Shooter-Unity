using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BossBolt
{
	public GameObject straightBolt;
	public GameObject curveBolt;
	public GameObject straightRoundBolt;
	public GameObject curveRoundBolt;
	public GameObject curveToPlayerRoundBolt;
}

[System.Serializable]
public class BossInfo
{
	public float speed;
	public float fireRate;
	public int health;			
	public int level;
	/// <summary>
	/// Number of mini waves in each big wave.
	/// </summary>
	public int miniWave;
	/// <summary>
	/// Number of bolts in each mini wave.
	/// </summary>
	public int numberOfBolts;
}

public class BossController : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	public float radius;
	public Transform bossShotSpawn;
	/// <summary>
	/// Shooting bolt delay
	/// </summary>
	public float startWait;
	public float waveWait;

	public BossBolt bolt;
	public BossInfo bossInfo;

	private List<int> shootingTypeList;
	private int numberOfShootingType = 6;

	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================

	void Start () {
		StartCoroutine(shootWaves());
        for (int i = 0; i < 50; i++)
        {
            //StartCoroutine(shootBoltCurveToPlayer(300, bolt.curveToPlayerRoundBolt));
        }
	}

	void Update () {

		if (rigidbody.position.z > 13)
		{
			//transform.Translate
			rigidbody.velocity = new Vector3 (0, 0, -bossInfo.speed);		
		} else 
		{
			rigidbody.velocity = new Vector3 (0,0,0);
		}

//		GameObject playerObject = GameObject.FindWithTag ("Player");
//		Vector3 playerDir = playerObject.transform.position - transform.position;
//		Vector3 foward = transform.forward;
//		
//		float dx = playerDir.x;
//		float dz = playerDir.z;
//
//		//print (dx + " : " + dz);
//		//float angle =  Vector3.Angle (playerDir, foward);
//		float angle =  Mathf.Atan (dx/dz) * Mathf.Rad2Deg;
//		print (angle);
	}

	//==============================================
	// Methods
	//==============================================
	
	// shooting behaviour is randomly generated
	IEnumerator shootWaves(){
		yield return new WaitForSeconds(startWait);
		while (true){
			//int random = Random.Range (1,5);
			//print(random);

			// Number of Shooting types in wave
			int shootingTypeCount = bossInfo.level/4 + 1;
//			for (int i = 0;i < shootingTypeCount;i++){
//				int random = Random.Range (1,numberOfShootingType + 1);
//				switch(random) {
//				case 1 : {
//
//				}
//				}
//			}

//			StartCoroutine(shootCircleBolts(bossInfo.miniWave+5, bossInfo.numberOfBolts+5, bolt.straightBolt));
//			StartCoroutine(shootCurveCircleBolts(bossInfo.miniWave+5, bossInfo.numberOfBolts+5, bolt.curveBolt));
//			StartCoroutine(shootReverseCurveCircleBolts(bossInfo.miniWave+5, bossInfo.numberOfBolts+5, bolt.curveBolt)); 
//			yield return StartCoroutine(shootBoltsToPlayer(bossInfo.numberOfBolts+5, bolt.straightRoundBolt));
//			yield return StartCoroutine(shootTwistedCircleBolts(bossInfo.miniWave+50, bossInfo.numberOfBolts-2, bolt.straightRoundBolt));
//			yield return StartCoroutine(shootBoltCurveToPlayer(bossInfo.numberOfBolts-2, bolt.curveToPlayerRoundBolt));

			yield return StartCoroutine (shootingWaveGenerate());

			yield return new WaitForSeconds(waveWait);
		}
	}

	IEnumerator shootingWaveGenerate(){
		int shootingTypeCount = bossInfo.level/4 + 1;
		for (int i = 0;i < shootingTypeCount;i++){
			int random = Random.Range (1,numberOfShootingType + 1);
			if (i == shootingTypeCount - 1){
				switch(random) {
				case 1 : {
					yield return StartCoroutine(shootCircleBolts(bossInfo.miniWave+5, 
								                                bossInfo.numberOfBolts+5, 
								                                bolt.straightBolt));
					break;
				}
				case 2 : {
					yield return StartCoroutine(shootCurveCircleBolts(bossInfo.miniWave+5,
					                                    			bossInfo.numberOfBolts+5,
					                                     			bolt.curveBolt));
					break;
				}
				case 3 : {
					yield return StartCoroutine(shootReverseCurveCircleBolts(bossInfo.miniWave+5, 
					                                            			bossInfo.numberOfBolts+5,
					                                            			bolt.curveBolt));
					break;
				}
				case 4 : {
					yield return StartCoroutine(shootBoltsToPlayer(bossInfo.numberOfBolts+5, 
					                                  				bolt.straightRoundBolt));
					break;
				}
				case 5 : {
					yield return StartCoroutine(shootTwistedCircleBolts(bossInfo.miniWave+10,
					                                       				bossInfo.numberOfBolts-2,
					                                       				bolt.straightRoundBolt));
					break;
				}
				case 6 : {
					yield return StartCoroutine(shootBoltCurveToPlayer(bossInfo.numberOfBolts-2,
                                                                    bolt.curveToPlayerRoundBolt));
					break;
				}
				}
			}else {
				switch(random) {
				case 1 : {
					StartCoroutine(shootCircleBolts(bossInfo.miniWave+5, 
					                                bossInfo.numberOfBolts+5, 
					                                bolt.straightBolt));
					break;
				}
				case 2 : {
					StartCoroutine(shootCurveCircleBolts(bossInfo.miniWave+5,
					                                     bossInfo.numberOfBolts+5,
					                                     bolt.curveBolt));
					break;
				}
				case 3 : {
					StartCoroutine(shootReverseCurveCircleBolts(bossInfo.miniWave+5, 
					                                            bossInfo.numberOfBolts+5,
					                                            bolt.curveBolt));
					break;
				}
				case 4 : {
					StartCoroutine(shootBoltsToPlayer(bossInfo.numberOfBolts+5, 
					                                  bolt.straightRoundBolt));
					break;
				}
				case 5 : {
					StartCoroutine(shootTwistedCircleBolts(bossInfo.miniWave+10,
					                                       bossInfo.numberOfBolts-2,
					                                       bolt.straightRoundBolt));
					break;
				}
				case 6 : {
					StartCoroutine(shootBoltCurveToPlayer(bossInfo.numberOfBolts-2,
					                                      bolt.curveToPlayerRoundBolt));
					break;
				}
				}
			}
		}
		yield return null;
	}

	// Differents Types of Shooting Methods
	#region Different Shooting types
	IEnumerator shootCircleBolts(int numberOfWaves, int numberOfBoltsEachWaves, GameObject gameObject){
		float angle = 360/(float)numberOfBoltsEachWaves;
		float randomStartAngle = Random.Range(0,0);
		for (int i = 0; i < numberOfWaves; i++){
			for (int j = 0; j < numberOfBoltsEachWaves; j++){
				
				float radAngle = Mathf.Deg2Rad * ((angle * j)+90.0f+randomStartAngle);
				
				Vector3 boltPosition = new Vector3(bossShotSpawn.position.x + radius*Mathf.Cos(radAngle),
				                                   0,
				                                   bossShotSpawn.position.z + radius*Mathf.Sin(radAngle));
				
				Quaternion boltRotation = Quaternion.Euler(0,-angle*j-randomStartAngle ,0);
				
				GameObject boltObject = (GameObject) Instantiate(gameObject, boltPosition, boltRotation);
			}
			yield return new WaitForSeconds(bossInfo.fireRate);
		}
	}
	
	IEnumerator shootCurveCircleBolts(int numberOfWaves, int numberOfBolts,GameObject gameObject)
	{
		float angle = 360/(float)numberOfBolts;
		for (int i = 0; i < numberOfWaves; i++){
			for (int j = 0; j < numberOfBolts; j++){
				
				float radAngle = Mathf.Deg2Rad * ((angle * j)+90.0f);
				
				Vector3 boltPosition = new Vector3(bossShotSpawn.position.x + radius*Mathf.Cos(radAngle),
				                                   0,
				                                   bossShotSpawn.position.z + radius*Mathf.Sin(radAngle));
				
				Quaternion boltRotation = Quaternion.Euler(0,-angle*j ,0);
				Instantiate(gameObject, boltPosition, boltRotation);
			}
			yield return new WaitForSeconds(bossInfo.fireRate);
		}
	}
	
	IEnumerator shootReverseCurveCircleBolts(int numberOfWaves, int numberOfBolts,GameObject gameObject)
	{
		float angle = 360/(float)numberOfBolts;
		for (int i = 0; i < numberOfWaves; i++){
			for (int j = 0; j < numberOfBolts; j++){
				
				float radAngle = Mathf.Deg2Rad * ((angle * j)+90.0f);
				
				Vector3 boltPosition = new Vector3(bossShotSpawn.position.x + radius*Mathf.Cos(radAngle),
				                                   0,
				                                   bossShotSpawn.position.z + radius*Mathf.Sin(radAngle));
				
				Quaternion boltRotation = Quaternion.Euler(0,-angle*j ,0);
				GameObject boltObject = (GameObject) Instantiate(gameObject, boltPosition, boltRotation);
				float rotateSpeed = gameObject.GetComponent<CurveBoltMover>().rotateSpeed;
				boltObject.GetComponent<CurveBoltMover>().rotateSpeed = -rotateSpeed;
			}
			yield return new WaitForSeconds(bossInfo.fireRate);
		}
	}

	IEnumerator shootBoltsToPlayer (int numberOfBolts,GameObject gameObject){
		for (int i = 0; i < numberOfBolts; i++){
			GameObject playerObject = GameObject.FindWithTag("Player");
			if (playerObject != null){
				PlayerController player = playerObject.GetComponent<PlayerController>();
				
				Vector3 boltPosition = new Vector3(bossShotSpawn.position.x, 
				                                   0, 
				                                   bossShotSpawn.position.z - radius);
				
				Vector3 relativePos = player.transform.position - boltPosition;
				Quaternion boltRotation = Quaternion.LookRotation(relativePos);
				Instantiate (gameObject, boltPosition, boltRotation);
			}
			yield return new WaitForSeconds(bossInfo.fireRate);
		}
	}

	IEnumerator shootTwistedCircleBolts(int numberOfBoltEachLine,int numberOfTwistedLines, GameObject gameObject){
		float lineAngle = 360/(float)numberOfTwistedLines;
		for (int i = 0; i < numberOfBoltEachLine; i++){
			float miniAngle = 9*i;
			for (int j = 0; j < numberOfTwistedLines; j++){
				float radAngle = Mathf.Deg2Rad * ((miniAngle)+ 90.0f + lineAngle*j);
				Vector3 boltPosition = new Vector3(bossShotSpawn.position.x + radius*Mathf.Cos(radAngle),
				                                   0,
				                                   bossShotSpawn.position.z + radius*Mathf.Sin(radAngle));
				
				Quaternion boltRotation = Quaternion.Euler(0,-miniAngle-lineAngle*j ,0);
				Instantiate(gameObject, boltPosition, boltRotation);
			}
			yield return new WaitForSeconds(0.1f);
		}

	}

	IEnumerator shootBoltCurveToPlayer (int numberOfBolts, GameObject gameObject){
		for (int i = 0; i < numberOfBolts; i++){

			Vector3 boltPosition = new Vector3(bossShotSpawn.position.x, 
			                                   0, 
			                                   bossShotSpawn.position.z - radius);

			Quaternion boltRotation = Quaternion.Euler(0,-180 ,0);

			Instantiate(gameObject, boltPosition, boltRotation);

			yield return new WaitForSeconds(bossInfo.fireRate);
		}
	}
	
	#endregion
}