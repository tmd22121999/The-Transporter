using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class LeaderBoard : MonoBehaviour
{

    public GameObject loading, networkError;
    public RowUI[] rowui;
    playerScore[] playerScores;
    class playerScore
    {
        public long id;
        public string name;

        public int score;
    }
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(GetData());
    }

    // Update is called once per frame

    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://myartistlist99.herokuapp.com/v1/leaderboard/hiscore");
        yield return www.SendWebRequest();
        loading.SetActive(false);
        if (www.isNetworkError)
        {
            networkError.SetActive(true);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            var n = new JSONObject();
            JSONNode ps = JSON.Parse(www.downloadHandler.text);
            Debug.Log(ps[0]["name"]);
            for (int i = 0; i < ps.Count; i++)
            {
                rowui[i].setText(i + 1, ps[i]["name"], ps[i]["score"]);
                if (i == 9)
                    break;
            }
        }
        /*string jsstring = @"[
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1},
            {""id"":2,""name"":""acbd"",""score"":1},{""id"":2,""name"":""acbd"",""score"":1}]
        ";
        JSONNode psl = JSON.Parse(jsstring);
        Debug.Log(psl.Count);
        */
    }

}



