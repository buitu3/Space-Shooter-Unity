using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSliderController : MonoBehaviour {

    public Slider BGMSlider;
    public Slider SFXSlider;

    private GameObject gameController;
    private GameObject gameInfo;
    private AudioSource backGroundMusic;
    private GameInfoContainer gameInfoContainer;

    void Awake()
    {
        // Find GameController
        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            // Get BGM audio component
            backGroundMusic = gameController.GetComponent<AudioSource>();
        }
        else
        {
            Debug.Log("Cannot find BGM component");
        }
        
        // Get Game Information Container
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
        
        // Set Game volume based on saved value
        BGMSlider.value = gameInfoContainer.BGM;
        SFXSlider.value = gameInfoContainer.SFX;
        backGroundMusic.volume = BGMSlider.value;
        AudioListener.volume = SFXSlider.value;
    }

    public void changeBGMVolume()
    {
        backGroundMusic.volume = BGMSlider.value;
        gameInfoContainer.BGM = BGMSlider.value;
    }

    public void changeSFXVolume()
    {
        AudioListener.volume = SFXSlider.value;
        gameInfoContainer.SFX = SFXSlider.value;
    }
}
