using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject settingsPanel;
    public GameObject levelSelectPanel;

    //Handles navigation of the main menu scene.

    public void Awake()
    {
        levelSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);
        SettingsHolder.instance.defaultSettings();
    }

    public void LoadByIndex(int sceneIndex) //Change to level select at some point.
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }


    public void gameSettingsMenu()
    {
        settingsPanel.SetActive(true);

        levelSelectPanel.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void levelSelect()
    {
        levelSelectPanel.SetActive(true);

        settingsPanel.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void returnToMenu()
    {
        mainMenu.SetActive(true);

        levelSelectPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
