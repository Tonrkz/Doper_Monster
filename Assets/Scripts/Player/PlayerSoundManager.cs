using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

    public static PlayerSoundManager instance;
    [SerializeField] AudioSource eatingSFX;
    [SerializeField] AudioSource deathSFX;

    void Start() {
        instance = this;
    }

    public void DeathSFX() {
        deathSFX.Play();
    }

    public void EatingSFX() {
        eatingSFX.Play();
    }
}
