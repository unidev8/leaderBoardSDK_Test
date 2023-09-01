using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using static System.Net.WebRequestMethods;
using UnityEngine.Networking;


public class LeaderBoardSDK : MonoBehaviour
{
    [System.Serializable]
    public class LeaderBoards
    {
        public string profileID;
        public string username;
        public float score;
        public int position;
        public int createAt;
    }

    private LeaderBoards[] leaderBoards; 
    private UnityWebRequest request;

    public IEnumerator GetLeaderBoardAPIData (string url)
    {


        UnityWebRequest request = UnityWebRequest.Get(url);
        request.SetRequestHeader("x-auth-server", "gamedev.7b5a2bb8-dfa7-4a2d-ab12-2fc644b08503");
        yield return request.SendWebRequest ();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError )
        {
            Debug.LogError(request.error);
        }
        else
        {
            string responseData = request.downloadHandler.text;
            leaderBoards = JsonUtility.FromJson<LeaderBoards[]>(responseData);
        }
    }

    public LeaderBoards[] GetLeaderBoardsArray()
    {
        return leaderBoards;
    }

    public void AddInfo (LeaderBoards addedInfo)
    {

    }
}