/*
==========================================
 Title: Player Stats
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
using UnityEngine.Networking;

public class PlayerStats : MonoBehaviour
{
    public void addData()
    {
        StartCoroutine(Post());
    }

    IEnumerator Post() //posts player stats after winning or losing a level
    {
        User usr = GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>().usr;

        string raw = "{" + $"\"victory\":{usr.victory},\"played\":{usr.played}" + "}";

        using (UnityWebRequest www = UnityWebRequest.Put($"https://api-heavent.herokuapp.com/users/{usr.id}", raw))
        {
            www.method = "PUT";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log("Error: " + www.error);
        }

        usr = null;
    }
}
