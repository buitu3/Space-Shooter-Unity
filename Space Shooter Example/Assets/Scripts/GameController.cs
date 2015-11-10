using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    // Create Singleton
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();
            }
            return _instance;
        }
    }          

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	public Transform bossSpawn;

	public GameObject boss;
    public Text bossHealthText;
    public Text bossLevelText;
    private BossController bossController;
    // Level of the previous Boss
    private int previousBossLevel;
    private bool bossAlive;

    public GameObject gameOverMenu;

    // Background Music
    private AudioSource BGM;

    private GameObject gameInfo;
    private GameInfoContainer gameInfoContainer;

	public float startWait;
	public float waveWait;

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

	void Awake () {
		// Init first boss
        GameObject bossObject = (GameObject)Instantiate(boss, bossSpawn.position, bossSpawn.rotation);
		bossController = bossObject.GetComponent<BossController>();
        BGM = GetComponent<AudioSource>();

        // Separate Background music from volume listener
        BGM.ignoreListenerVolume = true;

        // Get Game Information Container
        gameInfo = GameObject.FindWithTag("Game Info Container");
        if (gameInfo != null)
        {
            gameInfoContainer = gameInfo.GetComponent<GameInfoContainer>();
            DontDestroyOnLoad(gameInfo);
            updateVolume();
        }
        if (gameInfoContainer == null)
        {
            print("Cannot find GameInfoContainer component");
        }

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
    
    // Change Volume based on saved infomation
    void updateVolume()
    {
        BGM.volume = gameInfoContainer.BGM;
        AudioListener.volume = gameInfoContainer.SFX;
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
