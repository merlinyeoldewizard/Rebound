using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    //Reload the current active scene.
    public void ReloadScene()
    {
        GameManager.instance.gameState.unPauseGame();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    //Quit to main menu.
    public void Quit(int sceneIndex)
    {
        GameManager.instance.gameState.unPauseGame();
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
