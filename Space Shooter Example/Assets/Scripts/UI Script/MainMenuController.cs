using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================

    private GameObject gameInfo;
    private GameInfoContainer gameInfoContainer; 
    private AsyncOperation async;
	
	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================	

    IEnumerator Start()
    {
        // Set Game FPS
        Application.targetFrameRate = 60;
        
        // Get GameObject gameInfoContainer from Scene 
        gameInfo = GameObject.FindWithTag("Game Info Container");
        if (gameInfo != null)
        {
            gameInfoContainer = gameInfo.GetComponent<GameInfoContainer>();
            DontDestroyOnLoad(gameInfo);
        }
        if (gameInfoContainer == null)
        {
            print("Cannot find GameInfoContainer component");
        }
        
        // Load MainGame Level
        async = Application.LoadLevelAsync("Main");
        async.allowSceneActivation = false;
        yield return async;
        //async.allowSceneActivation = true;
        
        //StartCoroutine(loadGameOnBackGround());
        //Application.LoadLevel("Main");
    }

    //==============================================
    // Methods
    //==============================================
	
	public void startGame(){
		//Application.LoadLevel ("Main");
        async.allowSceneActivation = true;
        /*
        if (async.isDone)
        {
            async.allowSceneActivation = true;
        }
        */
	}
	
	public void exitGame(){
        // Save Information
        PlayerPrefs.SetFloat("BGM", gameInfoContainer.BGM);
        PlayerPrefs.SetFloat("SFX", gameInfoContainer.SFX);
        // Exit Game
		Application.Quit ();
	}

}
