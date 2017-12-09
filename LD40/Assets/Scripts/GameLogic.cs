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
    public Font scaryFont;
    public GameObject RedEye;
    public GameObject Redrum;


    [SerializeField]
    ParticleSystem thumbUpParticle;
    [SerializeField]
    ParticleSystem thumbDownParticle;
    Slider progressBar;
    GameState gState;
    int newMoneyDelta = 50;
    int followersDelta;
    HashtagGenerator hGenerator;
    bool scaryFontEnabled = false;
    

    private void Awake()
    {
        //progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        gState = GameObject.Find("GAMESTATE").GetComponent<GameState>();
        hGenerator = GameObject.Find("HASHTAGGENERATOR").GetComponent<HashtagGenerator>();
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

        if (gState.Health < 30)
        {
            scaryFontEnabled = true;
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
        if(gState.Followers > 1000 && gState.Followers < 10000)
        {
            hGenerator.waitTime -= 0.1f;
            if(hGenerator.waitTime < 1.0f)
            {
                hGenerator.waitTime = 1.0f;
            }
            if(RedEye.activeSelf == true)
            {
                RedEye.SetActive(false);
            }
            
        } else if (gState.Followers >= 10000)
        {
            hGenerator.waitTime -= 0.2f;
            if (hGenerator.waitTime < 1.0f)
            {
                hGenerator.waitTime = 1.0f;
            }
            RedEye.SetActive(true);
        } else if (gState.Followers >= 20000)
        {
            hGenerator.waitTime -= 0.2f;
            if (hGenerator.waitTime < 1.0f)
            {
                hGenerator.waitTime = 1.0f;
            }
            Redrum.SetActive(true);
        }
        

        if (TurnNumber < 10)
        {
            newMoneyDelta += 5;
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
        if (scaryFontEnabled == true)
        {
            Reaction1.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction1.color = Color.red;
            Reaction1.font = scaryFont;
            Reaction2.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction2.color = Color.red;
            Reaction2.font = scaryFont;
            Reaction3.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction3.color = Color.red;
            Reaction3.font = scaryFont;
            Reaction4.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction4.color = Color.red;
            Reaction4.font = scaryFont;
            Reaction5.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction5.color = Color.red;
            Reaction5.font = scaryFont;
        }
        else if (gState.Health < 50 || gState.Followers > 100000)
        {
            Reaction1.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction1.color = Color.red;
            Reaction2.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction2.color = Color.red;
            Reaction3.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction3.color = Color.red;
            Reaction4.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction4.color = Color.red;
            Reaction5.text = VeryPossitivePhrases[Random.Range(0, 15)];
            Reaction5.color = Color.red;
            
        } else
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
        gState.Health -= 1;
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
        if (scaryFontEnabled == true)
        {
            Reaction1.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction1.color = Color.red;
            Reaction1.font = scaryFont;
            Reaction2.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction2.color = Color.red;
            Reaction2.font = scaryFont;
            Reaction3.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction3.color = Color.red;
            Reaction3.font = scaryFont;
            Reaction4.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction4.color = Color.red;
            Reaction4.font = scaryFont;
            Reaction5.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction5.color = Color.red;
            Reaction5.font = scaryFont;
        }
        else if (gState.Health < 50 || gState.Followers > 100000) {
            Reaction1.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction1.color = Color.red;
            Reaction2.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction2.color = Color.red;
            Reaction3.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction3.color = Color.red;
            Reaction4.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction4.color = Color.red;
            Reaction5.text = VeryNegativePhrases[Random.Range(0, 15)];
            Reaction5.color = Color.red;
            
        } else
        {
            Reaction1.text = NegativePhrases[Random.Range(0, 15)];
            Reaction2.text = NegativePhrases[Random.Range(0, 15)];
            Reaction3.text = NegativePhrases[Random.Range(0, 15)];
            Reaction4.text = NegativePhrases[Random.Range(0, 15)];
            Reaction5.text = NegativePhrases[Random.Range(0, 15)];
        }
    }
        
}

