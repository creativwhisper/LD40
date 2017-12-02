using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtagReaction : MonoBehaviour {

    GameLogic TheGameLogic;
    HashtagGenerator hGenerator;

	// Use this for initialization
	void OnEnable () {
        TheGameLogic = GameObject.Find("GAMELOGIC").GetComponent<GameLogic>();
        hGenerator = GameObject.Find("HASHTAGGENERATOR").GetComponent<HashtagGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Happy()
    {
        if(hGenerator.CurrentHashtagMood == 0)
        {
            TheGameLogic.CorrectMood();
        } else
        {
            TheGameLogic.IncorrectMood();
        }
    }

    public void Sad()
    {
        if (hGenerator.CurrentHashtagMood == 1)
        {
            TheGameLogic.CorrectMood();
        }
        else
        {
            TheGameLogic.IncorrectMood();
        }
    }

    public void Silly()
    {
        if (hGenerator.CurrentHashtagMood == 2)
        {
            TheGameLogic.CorrectMood();
            TheGameLogic.PlayerHasReactedThisTurn = true;
        }
        else
        {
            TheGameLogic.IncorrectMood();
            TheGameLogic.PlayerHasReactedThisTurn = true;
        }
    }

    public void Inspirational()
    {
        if (hGenerator.CurrentHashtagMood == 3)
        {
            TheGameLogic.CorrectMood();
        }
        else
        {
            TheGameLogic.IncorrectMood();
        }
    }
}

