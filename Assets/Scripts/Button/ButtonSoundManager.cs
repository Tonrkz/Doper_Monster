using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour {

    [SerializeField] AudioSource buttonClickSFX;


    private static ButtonSoundManager instance = null;
    public static ButtonSoundManager Instance {
        get { return instance; }
    }
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ButtonClickSFX() {
        buttonClickSFX.Play();
    }
}
