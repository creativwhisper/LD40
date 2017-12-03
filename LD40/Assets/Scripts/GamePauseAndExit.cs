using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseAndExit : MonoBehaviour {

    public GameObject pauseScreen;

    public bool isGamePaused = false;

	// Use this for initialization
	void Start () {
        if(pauseScreen == null)
        {
            pauseScreen = GameObject.Find("Pause");
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetButtonDown("Cancel") && isGamePaused == false)
        {
            isGamePaused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        } else if (Input.GetButtonDown("Cancel") && isGamePaused == true)
        {
            Time.timeScale = 1;
            isGamePaused = false;
            SceneManager.LoadScene("Menu");
        }

        if( isGamePaused && Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1;
            isGamePaused = false;
            pauseScreen.SetActive(false);
        }


	}
}

