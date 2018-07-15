using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject HUD;
	// Use this for initialization
	void Start () {
        pauseMenuUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            gameIsPaused = !gameIsPaused;
        }
	}

    void Pause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        HUD.SetActive(false);
        AudioSource[] audioSourcesArray = FindObjectsOfType<AudioSource>();
        foreach (AudioSource Source in audioSourcesArray)
        {
            if(Source.tag != "pauseSource")
            Source.Pause();

        }
    }

    void Resume()
    {
        HUD.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        AudioSource[] audioSourcesArray = FindObjectsOfType<AudioSource>();
        foreach (AudioSource Source in audioSourcesArray)
        {
            Source.UnPause();

        }
    }
}
