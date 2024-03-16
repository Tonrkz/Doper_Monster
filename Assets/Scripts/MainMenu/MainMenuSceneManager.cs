using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour {
    public void GoToStageSelection() {
        SceneManager.LoadScene("StageSelection");
    }

    public void ButtonOnClickSFX() {
        GameObject.FindGameObjectWithTag("ButtonSound").GetComponent<ButtonSoundManager>().ButtonClickSFX();
    }

    public void GameExit() {
        Application.Quit();
    }
}
