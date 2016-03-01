using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	//==============================================
	// Constants
	//==============================================
	
	//==============================================
	// Fields
	//==============================================
	
	//==============================================
	// Getters and Setters
	//==============================================
	
	//==============================================
	// Unity Methods
	//==============================================
	
	//==============================================
	// Methods
	//==============================================

    void Awake()
    {
        Application.targetFrameRate = 30;
    }
	
	public void startGame(){
		Application.LoadLevel ("Main");
	}
	
	public void exitGame(){
		Application.Quit ();
	}
}
