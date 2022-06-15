/*
==========================================
 Title: Retain On Load
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 DO Hyun Nam
 Date: 14/06/2022
==========================================
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class RetainOnLoad : MonoBehaviour
{
    public User usr;


    // current level stats
    public int currentLevelId;
    public DateTime initialTime;
    public DateTime finalTime;

    // level loading
    public List<Level> lvl;
    public string currentLvlData;

    private void Awake()
    {        
        GameObject R = GameObject.Find("Retain");
        if(R != null && R != gameObject)
        {
            Destroy(R);
        }
    }

    public void setUser(User user)
    {
       usr = user;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && (SceneManager.GetActiveScene().name != "Menu" && SceneManager.GetActiveScene().name != "Login"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
