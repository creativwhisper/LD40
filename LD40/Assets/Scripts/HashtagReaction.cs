using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashtagReaction : MonoBehaviour {

    GameLogic TheGameLogic;
    HashtagGenerator hGenerator;
    GameState gameState;

	// Use this for initialization
	void OnEnable () {
        TheGameLogic = GameObject.Find("GAMELOGIC").GetComponent<GameLogic>();
        hGenerator = GameObject.Find("HASHTAGGENERATOR").GetComponent<HashtagGenerator>();
        gameState = GameObject.Find("GAMESTATE").GetComponent<GameState>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Happy()
    {
        if(hGenerator.CurrentHashtagMood == 0)
        {
            TheGameLogic.CorrectMood();
            TheGameLogic.PlayerHasReactedThisTurn = true;
        } else
        {
            TheGameLogic.IncorrectMood();
            TheGameLogic.PlayerHasReactedThisTurn = true;
        }
    }

    public void Sad()
    {
        if (hGenerator.CurrentHashtagMood == 1)
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
            TheGameLogic.PlayerHasReactedThisTurn = true;
        }
        else
        {
            TheGameLogic.IncorrectMood();
            TheGameLogic.PlayerHasReactedThisTurn = true;
        }
    }

    public void FakeMood()
    {
        gameState.Health -= 5;
        TheGameLogic.PlayerHasReactedThisTurn = true;
    }

    public void PersonalPost()
    {
        gameState.Health -= 15;
        gameState.Followers += (gameState.Followers * 50) / 100;
        StartCoroutine(MultipliyingFollowers());
    }

    IEnumerator MultipliyingFollowers()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(1f);
            gameState.Followers += (gameState.Followers * 50) / 100;
        }
    }
}

