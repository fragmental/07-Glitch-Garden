using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        print(slider);
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();

        //FindWinLabel(); in the course he created a function for this below, but idgaf
        winLabel = GameObject.Find("Win Label");
        if (!winLabel)
        {
            Debug.LogWarning("please create \"Win Label\" object");
        }
        winLabel.SetActive(false);
	}

	
	// Update is called once per frame
	void Update () {
        slider.value =  Time.timeSinceLevelLoad / levelSeconds;

        if (Time.timeSinceLevelLoad >= levelSeconds && isEndOfLevel == false)
        {
            HandleWindCondition();
        }
    }

    private void HandleWindCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);

        Invoke("LoadNextLevel", audioSource.clip.length);
        print("Fin");
        isEndOfLevel = true;
    }

    private void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    private void LoadNextlevel()
    {
        levelManager.LoadNextLevel();
    }
}
