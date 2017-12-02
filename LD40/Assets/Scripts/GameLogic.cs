using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    public bool PlayerHasReactedThisTurn = false;
    public bool ActionSelected = false;
    public bool ActionProcessing = false;
    public bool HashtagActive = false;
    public int TurnNumber = 1;
    public GameObject moodReactionCanvas;
    public float TimeBetweenTurns;

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
		
        if (!moodReactionCanvas.activeSelf && ActionSelected)
        {
            moodReactionCanvas.SetActive(true);
        } else if (moodReactionCanvas.activeSelf && !ActionSelected)
        {
            moodReactionCanvas.SetActive(false);
        }
	}

    IEnumerator TimeUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenTurns);
            TurnNumber++;
            UpdateCounters();
        }
    }

    void UpdateCounters()
    {
        PlayerHasReactedThisTurn = false;
        gState.Money -= newMoneyDelta;
        newMoneyDelta += 10;
        if (!PlayerHasReactedThisTurn)
        {
                    
            gState.Followers = (gState.Followers / 2) + 1;
        }
        else
        {
            gState.Followers += ((gState.Followers * 5) / 100) + 1;
        }

        // Debug.Log("Turn Processed");
        // Debug.Log(TurnNumber);
    }

    public void Photo()
    {
        ActionSelected = true;
        
    }

    public void Video()
    {
        ActionSelected = true;
        
    }

    public void Tweet()
    {
        ActionSelected = true;
        
    }

    public void LongPost()
    {
        ActionSelected = true;
        
    }

    public void CorrectMood()
    {
        Debug.Log("Correct!");
        HashtagActive = false;
        ActionSelected = false;
        gState.Followers += ((gState.Followers * 10) / 100) + 1;
    }

    public void IncorrectMood()
    {
        Debug.Log("IncorrectMood!");
        HashtagActive = false;
        ActionSelected = false;
        gState.Followers -= ((gState.Followers * 10) / 100) + 1;
    }

    /*public void FakeMood()
    {
        gState.Health -= 10;
        
    }

    public void PersonalPost()
    {
        gState.Health -= 15;
        // StartCoroutine(MultipliyingFollowers());
        gState.Followers += (gState.Followers * 50) / 100;
    }

    IEnumerator MultipliyingFollowers()
    {
        
        gState.Followers += (gState.Followers * 50) / 100;
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1f);
            gState.Followers += (gState.Followers * 50) / 100;
            
        }
        yield return null;
            
    }*/
}

