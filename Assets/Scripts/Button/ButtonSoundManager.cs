using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour {
    [SerializeField] AudioSource buttonClickSFX;

    public void ButtonClickSFX() {
        buttonClickSFX.Play();
    }
}
