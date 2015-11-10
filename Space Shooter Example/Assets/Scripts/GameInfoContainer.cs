using UnityEngine;
using System.Collections;

public class GameInfoContainer : MonoBehaviour {

    [HideInInspector]
    public float BGM;
    public float SFX;

    void Awake()
    {
        BGM = PlayerPrefs.GetFloat("BGM");
        SFX = PlayerPrefs.GetFloat("SFX");
    }
}
