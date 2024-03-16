using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

    public static PlayerSoundManager instance;
    [SerializeField] AudioSource eatingSFX;
    [SerializeField] AudioSource deathSFX;
    [SerializeField] AudioSource whooshSFX;

    void Start() {
        instance = this;
    }

    public void PlayWhooshSFX() {
        whooshSFX.Play();
    }

    public void PlayDeathSFX() {
        deathSFX.Play();
    }

    public void PlayEatingSFX() {
        eatingSFX.Play();
    }
}
