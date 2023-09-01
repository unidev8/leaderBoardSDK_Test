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

    public void getLeaderBoard()
    {
        LeaderBoardSDK leaderboard = new LeaderBoardSDK();
        leaderboard.GetLeaderBoardAPIData(ConstVars.serverURL);
        LeaderBoards[] leaderboardarry = leaderboard.GetLeaderBoardsArray();
        foreach (LeaderBoards aleaderboard in leaderboardarry)
        {
            GameObject textObject = GameObject.Instantiate(prefabText, scrView.transform );
            textObject.transform.SetParent(scrView.content.transform, false);
            TMP_Text textComponent = textObject.GetComponent<TMP_Text>();
            textComponent.text = aleaderboard.profileID + ": " + aleaderboard.username + ": " 
                + aleaderboard.score + ": " + aleaderboard.position;
        }
    }

}


public static class ConstVars
{
    public static string clientURL = "https://api.arenavs.com/api/v2/gamedev/client/FIGHTER/leaderboard/test-task-version-1";
    public static string serverURL = "https://api.arenavs.com/api/v2/gamedev/server/FIGHTER/leaderboard/test-task-version-1";
}
