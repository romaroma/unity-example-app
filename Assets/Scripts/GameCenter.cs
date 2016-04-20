using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.GameCenter;

public class GameCenter : MonoBehaviour {
    bool isGameCenterAuth = false;
    long score = 3; // number of levels completed
    public ScrollingTextArea console;

    public void authCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Authentication successful");
            this.console.Append("Authentication successful");
            string userInfo = "Username: " + Social.localUser.userName +
                "\nUser ID: " + Social.localUser.id +
                "\nIsUnderage: " + Social.localUser.underage;
            Debug.Log(userInfo);
            this.console.Append(userInfo);

            isGameCenterAuth = true;
        }
        else
        {
            Debug.Log("Authentication failed");
            this.console.Append("Authentication failed");
        }
    }

    public void scoreSubmissionCallback(bool success)
    {
        if (success)
        {
            Debug.Log("Score submission success");
            this.console.Append("Score submission success");
        }
        else
        {
            Debug.Log("Score submission failed");
            this.console.Append("Score submission failed");
        }
    }

	// Use this for initialization
	void Start () {
        Social.localUser.Authenticate(authCallback);
    }
	
	// Update is called once per frame
	void Update () {
        // send one result to leaderboard
	    if (isGameCenterAuth)
        {
            // what a trick!
            isGameCenterAuth = false;
            // submit a score
            Social.ReportScore(score, "T001", scoreSubmissionCallback);
            // show leaderboard
            Social.ShowLeaderboardUI();
        }
	}
}
