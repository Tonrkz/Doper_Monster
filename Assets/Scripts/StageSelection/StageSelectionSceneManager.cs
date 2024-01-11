using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectionSceneManager : MonoBehaviour {
    public void GotoTestStage() {
        SceneManager.LoadScene(2);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene(0);
    }
}
