using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

	public GameObject bossExplosion;
	public GameObject playerExplosion;
    //public GameObject boss;
    
	private BossController boss;

    private GameController gameController;
	//private GameController gameController;

	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================

    void Awake()
    {
        /*
        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameControllerScript = gameController.GetComponent<GameController>();
        }
        if (gameControllerScript == null)
        {
            Debug.Log("Cannot find GameController script");
        }
        */
        gameController = GameController.Instance;
    }

    /*
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameObject != null){
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		if (gameController == null){
			Debug.Log("Cannot find GameController script");
		}
	}
	*/

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && this.tag == "BossBolt"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			//Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            gameController.endGame();
            return;
		}
        if (other.tag == "Boss" && this.tag == "PlayerBolt")
        {

            GameObject bossObject = GameObject.FindWithTag("Boss");
            if (bossObject != null)
            {
                boss = bossObject.GetComponent<BossController>();
            }
            if (boss == null)
            {
                Debug.Log("cannot find boss script");
            }
            boss.bossInfo.health -= 10;
            gameController.updateBossHealthText();
            Destroy(gameObject);
            if (boss.bossInfo.health <= 0)
            {
                Instantiate(bossExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                //gameController.destroyBoss();
                //gameController.setBossAlive(false);
                //StartCoroutine (gameController.spawnBoss());
            }
        }   
	}

	//==============================================
	// Methods
	//==============================================
}
