using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HashtagGenerator : MonoBehaviour {

    public GameObject SocialCanvas;
    public GameLogic TheGameLogic;
    public string[] PossibleHashtags;
    public string[] HappyHashtag;
    public string[] SadHashtag;
    public string[] SillyHashtag;
    public string[] InspirationalHashtag;
    public string NewHashtag;
    public int CurrentHashtagMood;

    Text hashtagText;
    [SerializeField]
    float waitTime;

	// Use this for initialization
	void Start () {
        hashtagText = GameObject.Find("Hashtag").GetComponent<Text>();        
        StartCoroutine(GenerateNewHashtag());
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

    IEnumerator GenerateNewHashtag()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            CurrentHashtagMood = Random.Range(0, 4);
            if(CurrentHashtagMood == 0)
            {
                NewHashtag = HappyHashtag[Random.Range(0, HappyHashtag.Length + 1)];
            }
            else if(CurrentHashtagMood == 1)
            {
                NewHashtag = SadHashtag[Random.Range(0, SadHashtag.Length + 1)];
            }
            else if (CurrentHashtagMood == 2)
            {
                NewHashtag = SillyHashtag[Random.Range(0, SillyHashtag.Length + 1)];
            }
            else if (CurrentHashtagMood == 3)
            {
                NewHashtag = InspirationalHashtag[Random.Range(0, InspirationalHashtag.Length + 1)];
            } 
            
            TheGameLogic.HashtagActive = true;
            hashtagText.text = NewHashtag;
        }
    }
}

