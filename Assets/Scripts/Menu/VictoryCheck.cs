/*
==========================================
 Title: Victory Check
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 DO Hyun Nam
 Date: 14/06/2022
==========================================
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class VictoryCheck : MonoBehaviour
{
    //If all bosses are defeated add wins to current logged in player through put mehtod

    List<GameObject> Bosses = new List<GameObject>();
    public LevelStats lvlStats;

    public void Update()
    {
        Bosses = GameObject.FindGameObjectsWithTag("Boss").ToList();
    }

    public void DeadBoss(GameObject boss)
    {
        if(Bosses.Contains(boss))
        {
            Bosses.Remove(boss);
        }

        if(Bosses.Count <= 0)
        {
            if(SceneManager.GetActiveScene().name != "Editor")
            {
                GameManager.instance.player.Heal(GameManager.instance.player.maxHitpoint);
                RetainOnLoad retain = GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>();
                retain.finalTime = DateTime.Now;
                lvlStats.getData( Convert.ToInt32((retain.finalTime-retain.initialTime).TotalSeconds), 1, 0);
                SceneManager.LoadScene("Win");
                
            }
            
        }
    }
   
}