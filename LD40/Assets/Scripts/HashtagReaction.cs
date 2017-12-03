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
        gameState.Health -= 10;
        gameState.Followers += ((gameState.Followers * 10) / 100) + 1;
        TheGameLogic.PlayerHasReactedThisTurn = true;
        TheGameLogic.CorrectMood();
    }

    public void PersonalPost()
    {
        gameState.Health -= 15;
        if (gameState.Followers < 1000)
        {
            gameState.Followers += (gameState.Followers * 50) / 100;
            gameState.Followers += (gameState.Followers * 50) / 100;
            gameState.Followers += (gameState.Followers * 50) / 100;
        }
        else if (gameState.Followers > 1001 && gameState.Followers < 100000)
        {
            gameState.Followers += (gameState.Followers * 40) / 100;
            gameState.Followers += (gameState.Followers * 30) / 100;
            gameState.Followers += (gameState.Followers * 20) / 100;
        }
        else
        {
            gameState.Followers += (gameState.Followers * 30) / 100;
            gameState.Followers += (gameState.Followers * 20) / 100;
        }
        TheGameLogic.PlayerHasReactedThisTurn = true;
        TheGameLogic.CorrectMood();
    }

    
}

