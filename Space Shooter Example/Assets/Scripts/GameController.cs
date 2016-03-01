using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	public Transform bossSpawn;
	public GameObject boss;
	//public GUIText bossHealthText;
	//public GUIText bossLevelText;
    public Text bossHealthText;
    public Text bossLevelText;
    public GameObject gameOverMenu;

	public float startWait;
	public float waveWait;
	
	private BossController bossController;
	private int previousBossLevel;				// Level of the previous Boss
	//private GameObject bossObject;

	private bool bossAlive;

	//==============================================
	// Getters and Setters
	//==============================================

	public bool isBossAlive(){
		return this.bossAlive;
	}

	public void setBossAlive(bool bossAlive){
		this.bossAlive = bossAlive;
	}

	//==============================================
	// Unity Methods
	//==============================================

	void Start () {
		// Init first boss
        GameObject bossObject = (GameObject)Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
		bossController = bossObject.GetComponent<BossController>();
		bossAlive = true;
		previousBossLevel = bossController.bossInfo.level;
		StartCoroutine(spawnWaves());			// Spawn Boss continously

		updateBossHealthText();
		updateBossLevelText();
	}

	//==============================================
	// Methods
	//==============================================

    /// <summary>
    /// Spawn new boss with higher level if current boss is destroyed.
    /// </summary>
	IEnumerator spawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			GameObject bossObject = GameObject.FindWithTag("Boss");
			if (bossObject == null){
				bossObject = (GameObject) Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
				bossController = bossObject.GetComponent<BossController>();
				bossController.bossInfo.level = previousBossLevel + 1;
				bossController.bossInfo.health += (bossController.bossInfo.level-1) * 20;
				bossController.bossInfo.numberOfBolts += (bossController.bossInfo.level-1);
				if (bossController.bossInfo.miniWave < 6){
					bossController.bossInfo.miniWave += (bossController.bossInfo.level-1);
				}
				previousBossLevel = bossController.bossInfo.level;
				bossAlive = true;
				updateBossHealthText();
				updateBossLevelText();
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void updateBossHealthText(){
		if (bossController.bossInfo.health < 0){
			bossHealthText.text = "Boss Health : 0";
		}else{
			bossHealthText.text = "Boss Health : " + bossController.bossInfo.health;
		}
	}

	public void updateBossLevelText(){
		bossLevelText.text = "Boss Level : " + bossController.bossInfo.level;
	}

	public void endGame(){
        gameOverMenu.SetActive(true);
        //Time.timeScale = 0.0f;
	}

	/*
	public IEnumerator spawnBoss(){
		//yield return new WaitForSeconds(startWait);
		print ("spawn");
		GameObject bossObject = GameObject.FindWithTag("Boss");
		//if (bossObject == null){
			bossObject = (GameObject) Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
			bossController = bossObject.GetComponent<BossController>();
			bossController.bossInfo.level = previousBossLevel + 1;
			bossController.bossInfo.health += (bossController.bossInfo.level-1) * 10; 
			previousBossLevel = bossController.bossInfo.level;
			bossAlive = true;
			updateBossHealthText();
			updateBossLevelText();
		//}
		yield return new WaitForSeconds(waveWait);

	}
	*/
}
