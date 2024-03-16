using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSoundManager : MonoBehaviour {

    [SerializeField] AudioSource backgroundMusic;

    public void BackgroundMusic() {
        backgroundMusic.Play();
    }

    public void ButtonOnClickSFX() {
        GameObject.FindGameObjectWithTag("ButtonSound").GetComponent<ButtonSoundManager>().ButtonClickSFX();
    }
}
