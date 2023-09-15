using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LeaderBoardSDK;
using TMPro;
using System.Threading.Tasks;


public class usingSDK : MonoBehaviour
{
    public ScrollRect scrView;
    public GameObject prefabText;

    public async void GetLeaderBoard()
    {
        Debug.Log("Start Debug.log in usingSDK class");

        LeaderBoardSDK leaderboardSDK = new LeaderBoardSDK();
        Debug.Log("before await GetLeaderBoardAPIData in usingSDK class");
        await leaderboardSDK.GetLeaderBoardAPIData(ConstVars.serverURL);
        Debug.Log("after await GetLeaderBoardAPIData in usingSDK class");
        LeaderBoards[] leaderboardArray;
        leaderboardArray = leaderboardSDK.GetLeaderBoardsArray();
        if (leaderboardArray == null)
            return;
        foreach (LeaderBoards aLeaderboard in leaderboardArray)
        {
            GameObject textObject = GameObject.Instantiate(prefabText, scrView.transform );
            textObject.transform.SetParent(scrView.content.transform, false);
            TMP_Text textComponent = textObject.GetComponent<TMP_Text>();
            textComponent.text = aLeaderboard.profileID + ": " + aLeaderboard.username + ": " 
                + aLeaderboard.score + ": " + aLeaderboard.position;
        }
    }
    
}



public static class ConstVars
{
    public static string clientURL = "https://api.arenavs.com/api/v2/gamedev/client/fighter/leaderboard/test-task/1";
    public static string serverURL = "https://api.arenavs.com/api/v2/gamedev/server/fighter/leaderboard/test-task/1";
}
