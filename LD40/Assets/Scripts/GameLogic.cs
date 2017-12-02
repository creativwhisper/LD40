using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public bool ActionProcessing;
    public bool HashtagActive;

    Slider progressBar;
    GameState gState;

    private void Awake()
    {
        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
    }
    // Use this for initialization
    void Start () {
        StartCoroutine(TimeUpdate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator TimeUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            UpdateCounters();
        }
    }

    void UpdateCounters()
    {
        Debug.Log("Turn Processed");
    }

    void Photo()
    {

    }

    void Video()
    {

    }

    void Tweet()
    {

    }

    void LongPost()
    {

    }
}

