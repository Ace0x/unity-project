/*
==========================================
 Title: Level Selector
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

public class LevelSelector : MonoBehaviour
{
    public void ToMenu()//when played is selected, level is loaded
    {     
        SceneManager.LoadScene("LevelLoad");
    }
}
