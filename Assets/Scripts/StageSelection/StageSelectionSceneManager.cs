using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectionSceneManager : MonoBehaviour {
    public void GotoTestStage() {
        SceneManager.LoadScene("TestGameplay");
    }

    public void GoToEasyStage() {
        SceneManager.LoadScene("EasyStage");
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
