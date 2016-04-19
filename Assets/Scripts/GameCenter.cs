using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenter : MonoBehaviour {

    public void authCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Authentication successful");
            string userInfo = "Username: " + Social.localUser.userName +
                "\nUser ID: " + Social.localUser.id +
                "\nIsUnderage: " + Social.localUser.underage;
            Debug.Log(userInfo);
        }
        else
        {
            Debug.Log("Authentication failed");
        }
    }

	// Use this for initialization
	void Start () {
        Social.localUser.Authenticate(authCallback);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
