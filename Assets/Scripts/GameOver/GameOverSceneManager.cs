using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour {

    public void Exit() {
        Application.Quit();
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
