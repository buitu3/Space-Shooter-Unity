using UnityEngine;
using System.Collections;

public class PauseGameMenuController : MonoBehaviour {

    public void resumeGame()
    {
        Time.timeScale = 1.0f;
        this.gameObject.SetActive(false);
    }

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
