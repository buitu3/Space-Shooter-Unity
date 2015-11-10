using UnityEngine;
using System.Collections;

public class GameOverMenuController : MonoBehaviour {

    public void resetGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void quitGame()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel("Main_Menu");
    }
}
