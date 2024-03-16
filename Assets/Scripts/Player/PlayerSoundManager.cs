using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour {

    public static PlayerSoundManager instance;
    [SerializeField] AudioSource eatingSFX;

    void Start() {
        instance = this;
    }

    public void EatingSFX() {
        eatingSFX.Play();
    }
}
