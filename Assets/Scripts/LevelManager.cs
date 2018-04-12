using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled, use a positive number in seconds");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {

        Debug.Log("level load requested for:" + name);
        Application.LoadLevel(name);
        //SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {


        Application.LoadLevel(Application.loadedLevel + 1);
    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }



}
