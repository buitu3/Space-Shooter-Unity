using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeSliderController : MonoBehaviour {

    public Slider BGMSlider;
    public Slider SFXSlider;

    private GameObject gameController;
    private AudioSource backGroundMusic;

    void Awake()
    {
        gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            backGroundMusic = gameController.GetComponent<AudioSource>();
            backGroundMusic.ignoreListenerVolume = true;
        }
        else
        {
            Debug.Log("Cannot find BGM component");
        }
    }

    public void changeBGMVolume()
    {
        backGroundMusic.volume = BGMSlider.value;
    }

    public void changeSFXVolume()
    {
        AudioListener.volume = SFXSlider.value;
    }
}
