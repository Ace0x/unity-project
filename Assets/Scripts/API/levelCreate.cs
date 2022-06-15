/*
==========================================
 Title: Level Create
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
using UnityEngine.UI;
using TMPro;
using System;

public class levelCreate : MonoBehaviour {
 
    public TMP_InputField _name;
    public GameObject Naming;
    string _levelDoc;
    private RetainOnLoad retain;

    private void Update() {
        if(retain == null && GameObject.Find("Retain") != null)
            retain = GameObject.Find("Retain").GetComponent<RetainOnLoad>();
    }    
    
    public void ActivateNaming() //activate naming template
    {
        Level_Manager lvManager = GameObject.Find("LevelManager").gameObject.GetComponent<Level_Manager>();
        lvManager.Savelevel();
        Naming.SetActive(true);
    }

    public void GetLevel() // get level from level list
    {
        Level_Manager lvManager = GameObject.Find("LevelManager").gameObject.GetComponent<Level_Manager>();
        _levelDoc = lvManager.GetJson().Replace((char)34, (char)39).Replace("\n", "");
        Login();
    }

    public void DeActivateNaming()
    {
        GetLevel();
        Naming.SetActive(false);
    }

    public void CloseTab() 
    {
        Naming.SetActive(false);
    }

    public void Login() 
    {
        StartCoroutine(Post());
    }
 
    IEnumerator Post() //post levels to DB
    {
        var user = new UserLevel
        {
            userId = GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>().usr.id.ToString(),
            name = _name.text,
            levelData = _levelDoc,
        };
        user.totalEnemies = user.totalBosses = user.levelData.Split("Boss").Length - 1;
        user.totalEnemies += user.levelData.Split("SmallEnemy").Length - 1;
        Debug.Log(user.totalEnemies);
        Debug.Log(user.totalBosses);
        var body = JsonUtility.ToJson(user);
        Debug.Log(body);
        
        using (UnityWebRequest www = UnityWebRequest.Put("https://api-heavent.herokuapp.com/levels", body))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();
        }

        user = null;

    }

    
}

public class UserLevel
{
    public string userId;
    public string name;
    public string levelData;
    public int totalEnemies;
    public int totalBosses;
}