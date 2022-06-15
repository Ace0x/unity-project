/*
==========================================
 Title: Play Level
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 Do Hyun Nam
 Date: 14/06/2022
==========================================
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

public class PlayLevel : MonoBehaviour
{

    public void Playlvl()
    {
        RetainOnLoad retain = GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>();
        retain.currentLvlData = 
            gameObject.transform.parent.gameObject.GetComponent<entryData>().lvlData;
        retain.currentLevelId =
            Int32.Parse(gameObject.transform.parent.gameObject.GetComponent<entryData>().lvlID);
        SceneManager.LoadScene("LevelLoad");
        retain.initialTime = DateTime.Now;
    }

    public void LikeLvl()
    {
        StartCoroutine(LikeDislike(Int32.Parse(gameObject.transform.parent.gameObject.GetComponent<entryData>().lvlID), 1, 0));
    }

    public void DislikeLvl()
    {
        StartCoroutine(LikeDislike(Int32.Parse(gameObject.transform.parent.gameObject.GetComponent<entryData>().lvlID), 0, 1));
    }

    IEnumerator LikeDislike(int level, int like, int dislike)
    {
        Level lvl = new Level();

        using (UnityWebRequest www = UnityWebRequest.Get($"https://api-heavent.herokuapp.com/levels/{level}"))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.Success)
            {
                if(www.downloadHandler.text != "null")
                {
                    string raw = www.downloadHandler.text;
                    lvl = JsonUtility.FromJson<Level>(raw);
                }
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        lvl.likes += like;
        lvl.dislikes += dislike;

        string updatedLvl = JsonUtility.ToJson(lvl);

        using (UnityWebRequest www = UnityWebRequest.Put($"https://api-heavent.herokuapp.com/levels/{level}", updatedLvl))
        {
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log("Error: " + www.error);
        }
    }
}