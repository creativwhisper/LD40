using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public int Health = 100;
    public int Followers = 100;
    public int Money = 1000;
    public SpriteRenderer RedEye;
    Color color;

    // Keep them serialized for debugging, hide them on final project
    [SerializeField]
    Text healthText;
    [SerializeField]
    Text followersText;
    [SerializeField]
    Text moneyText;

    private void Awake()
    {
        healthText = GameObject.Find("Health").GetComponent<Text>();
        followersText = GameObject.Find("Followers").GetComponent<Text>();
        moneyText = GameObject.Find("Money").GetComponent<Text>();
        RedEye = GameObject.Find("Red Eye").GetComponent<SpriteRenderer>();
        
    }

    private void Update()
    {
        // Game Over controller
        if(Health <= 0)
        {
            YouKillYourself();
        } else if (Money <= 0)
        {
            YouStarveToDeath();
        } 

        healthText.text = "Mental Health: " + Health + " / 100";
        /*Color col = RedEye.color;
        color.a = 1.0f - Health/100;
        RedEye.color = color;*/
        
        if (Health < 50 && Health > 20)
        {
            healthText.color = Color.yellow;
        } else if (Health < 20)
        {
            healthText.color = Color.red;
        }
        followersText.text = "Followers: " + Followers;
        moneyText.text = "Money: " + Money;
    }

    void YouKillYourself()
    {
        //Debug.Log("You Killed Yourself due to stress");
    }

    void YouStarveToDeath()
    {
        //Debug.Log("You are broke and die from inanition");
    }
}

