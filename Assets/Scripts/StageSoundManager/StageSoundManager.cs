using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSoundManager : MonoBehaviour {

    [SerializeField] AudioSource backgroundMusic;

    private void Awake() {
        GameObject.FindGameObjectWithTag("ButtonSound").GetComponent<ButtonSoundManager>().StopMainMenuBGM();
    }

    public void BackgroundMusic() {
        backgroundMusic.Play();
    }

    public void ButtonOnClickSFX() {
        GameObject.FindGameObjectWithTag("ButtonSound").GetComponent<ButtonSoundManager>().ButtonClickSFX();
    }
}
