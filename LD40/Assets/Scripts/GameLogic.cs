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
    public int[] LastActionUsed;
    public string[] PossitivePhrases;
    public string[] NegativePhrases;
    public string[] VeryPossitivePhrases;
    public string[] VeryNegativePhrases;
    public Text Reaction1;
    public Text Reaction2;
    public Text Reaction3;
    public Text Reaction4;
    public Text Reaction5;
    public GameObject PhotoGO;
    public GameObject TweetGO;
    public GameObject VideoGO;
    public GameObject PostGO;


    [SerializeField]
    ParticleSystem thumbUpParticle;
    [SerializeField]
    ParticleSystem thumbDownParticle;
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
        
        gState.Money -= newMoneyDelta;
        if (TurnNumber < 10)
        {
            newMoneyDelta += 10;
        } else if (TurnNumber >= 10 && TurnNumber < 30)
        {
            newMoneyDelta += 30;
        } else if (TurnNumber >= 30)
        {
            newMoneyDelta += 50;
        }

        if (!PlayerHasReactedThisTurn)
        {
            if (gState.Followers < 1000)
            {
                gState.Followers -= ((gState.Followers * 10) / 100) + 1;
            } else if (gState.Followers >= 1000 && gState.Followers < 100000)
            {
                gState.Followers -= ((gState.Followers * 25) / 100) + 50;
            } else
            {
                gState.Followers -= ((gState.Followers * 40) / 100) + 1000;
            }
        }
        else
        {
            gState.Followers += ((gState.Followers * 5) / 100) + 1;
        }
        PlayerHasReactedThisTurn = false;
        gState.Money += (gState.Followers / 20) + 1;
        // Debug.Log("Turn Processed");
        // Debug.Log(TurnNumber);
    }

    public void Photo()
    {
        ActionSelected = true;
        VideoGO.SetActive(false);
        TweetGO.SetActive(false);
        PostGO.SetActive(false);
        PhotoGO.SetActive(true);
    }

    public void Video()
    {
        ActionSelected = true;
        VideoGO.SetActive(true);
        TweetGO.SetActive(false);
        PostGO.SetActive(false);
        PhotoGO.SetActive(false);
    }

    public void Tweet()
    {
        ActionSelected = true;
        VideoGO.SetActive(false);
        TweetGO.SetActive(true);
        PostGO.SetActive(false);
        PhotoGO.SetActive(false);
    }

    public void LongPost()
    {
        ActionSelected = true;
        VideoGO.SetActive(false);
        TweetGO.SetActive(false);
        PostGO.SetActive(true);
        PhotoGO.SetActive(false);
    }

    public void CorrectMood()
    {
        //Debug.Log("Correct!");
        HashtagActive = false;
        ActionSelected = false;
        if (gState.Followers < 1000)
        {
            gState.Followers += ((gState.Followers * 20) / 100) + 10;
        } else if (gState.Followers > 1001 && gState.Followers < 100000){
            gState.Followers += ((gState.Followers * 15) / 100) + 100;
        } else
        {
            gState.Followers += ((gState.Followers * 10) / 100) + 200;
        }
        thumbUpParticle.Play();
        if (gState.Health < 50 || gState.Followers > 100000)
        {
            Reaction1.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = VeryPossitivePhrases[Random.Range(0, 15)];
        }
        else
        {
            Reaction1.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = PossitivePhrases[Random.Range(0, 15)];
        }
    }

    public void IncorrectMood()
    {
        //Debug.Log("IncorrectMood!");
        HashtagActive = false;
        ActionSelected = false;
        if (gState.Followers <= 1000)
        {
            gState.Followers -= ((gState.Followers * 10) / 100) + 1;
        }
        else if (gState.Followers > 1001 && gState.Followers < 100000)
        {
            gState.Followers -= ((gState.Followers * 15) / 100) + 50;
        }
        else
        {
            gState.Followers -= ((gState.Followers * 20) / 100) + 100;
        }
        
        thumbDownParticle.Play();
        if (gState.Health < 50 || gState.Followers > 100000)
        {
            Reaction1.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction2.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction3.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction4.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction5.text = VeryNegativePhrases[Random.Range(0, 15)];
        }
        else
        {
            Reaction1.text = NegativePhrases[Random.Range(0, 15)];
            Reaction2.text = NegativePhrases[Random.Range(0, 15)];
            Reaction3.text = NegativePhrases[Random.Range(0, 15)];
            Reaction4.text = NegativePhrases[Random.Range(0, 15)];
            Reaction5.text = NegativePhrases[Random.Range(0, 15)];
        }
    }

    public void FakeMood()
    {
        gState.Health -= 10;
        gState.Followers += ((gState.Followers * 10) / 100) + 1;

        HashtagActive = false;
        ActionSelected = false;
        
        if (gState.Health < 50 || gState.Followers > 100000)
        {
            Reaction1.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = VeryPossitivePhrases[Random.Range(0, 15)];
        }
        else
        {
            Reaction1.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = PossitivePhrases[Random.Range(0, 15)];
        }
        thumbUpParticle.Play();
    }

    public void PersonalPost()
    {
        thumbUpParticle.Play();
        HashtagActive = false;
        ActionSelected = false;
        gState.Health -= 15;
        // StartCoroutine(MultipliyingFollowers());
        if (gState.Followers < 1000)
        {
            gState.Followers += (gState.Followers * 50) / 100;
            gState.Followers += (gState.Followers * 50) / 100;
            gState.Followers += (gState.Followers * 50) / 100;
        }
        else if (gState.Followers > 1001 && gState.Followers < 100000)
        {
            gState.Followers += (gState.Followers * 40) / 100;
            gState.Followers += (gState.Followers * 30) / 100;
            gState.Followers += (gState.Followers * 20) / 100;
        }
        else
        {
            gState.Followers += (gState.Followers * 30) / 100;
            gState.Followers += (gState.Followers * 20) / 100;           
        }
        if (gState.Health < 50 || gState.Followers > 100000)
        {
            Reaction1.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = VeryPossitivePhrases[Random.Range(0, 15)];
        }
        else
        {
            Reaction1.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction2.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction3.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction4.text = PossitivePhrases[Random.Range(0, 15)];
            Reaction5.text = PossitivePhrases[Random.Range(0, 15)];
        }
        
    }
    
}

