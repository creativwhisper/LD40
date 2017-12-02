using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HashtagGenerator : MonoBehaviour {

    public GameObject SocialCanvas;
    public GameLogic TheGameLogic;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (TheGameLogic.HashtagActive && !SocialCanvas.activeSelf)
        {
            SocialCanvas.SetActive(true);
        } else if (!TheGameLogic.HashtagActive && SocialCanvas.activeSelf)
        {
            SocialCanvas.SetActive(false);
        }
	}
}

