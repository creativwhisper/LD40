using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public bool PlayerHasReactedThisTurn = false;
    public bool ActionProcessing = false;
    public bool HashtagActive = false;
    public int TurnNumber = 1;

    Slider progressBar;
    GameState gState;
    int newMoneyDelta = 100;
    int followersDelta;

    private void Awake()
    {
        //progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        gState = GameObject.Find("GAMESTATE").GetComponent<GameState>();
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
            yield return new WaitForSeconds(2f);
            TurnNumber++;
            UpdateCounters();
        }
    }

    void UpdateCounters()
    {
        gState.Money -= newMoneyDelta;
        newMoneyDelta += 10;
        if (PlayerHasReactedThisTurn)
        {

        } else
        {
            gState.Followers = (gState.Followers / 2) + 1;
        }

        Debug.Log("Turn Processed");
        Debug.Log(TurnNumber);
    }

    public void Photo()
    {
        HashtagActive = false;
    }

    public void Video()
    {
        HashtagActive = false;
    }

    public void Tweet()
    {
        HashtagActive = false;
    }

    public void LongPost()
    {
        HashtagActive = false;
    }
}

