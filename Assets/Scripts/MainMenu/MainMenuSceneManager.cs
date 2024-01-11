using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour {
    public void GoToStageSelection() {
        SceneManager.LoadScene(1);
    }

    public void GameExit() {
        Application.Quit();
    }
}
