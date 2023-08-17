using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LeaderBoardSDK;
using TMPro;



public class usingSDK : MonoBehaviour
{
    public ScrollRect scrView;
    public GameObject prefabText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void getClientLeaderBoard()
    {
        LeaderBoardSDK leaderboard = new LeaderBoardSDK();
        leaderboard.GetLeaderBoardAPIData(ConstVars.clientURL);
        LeaderBoards[] leaderboardarry = leaderboard.GetLeaderBoardsArray();
        foreach (LeaderBoards aleaderboard in leaderboardarry)
        {
            GameObject textObject = GameObject.Instantiate(prefabText, scrView.transform );
            textObject.transform.SetParent(scrView.content.transform, false);
            TMP_Text textComponent = textObject.GetComponent<TMP_Text>();
            textComponent.text = aleaderboard.profileID + ": " + aleaderboard.username + ": " + aleaderboard.score + ": " + aleaderboard.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
