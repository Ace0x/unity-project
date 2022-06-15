/*
==========================================
 Title: Play Test
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

public class PlayTest : MonoBehaviour
{

    public static bool pressEdit = true;
    public static bool pressPlay = false;
    public GameObject EditorUI;
    public GameObject PlayUI;
   
    // Update is called once per frame

   //editor play and freeze funcions for playtest
    void Update()
    {
        if (pressEdit)
            Edit();
        if (pressPlay)
            Play();
    }

    public void EditClick()
    {
        pressEdit = true;
        pressPlay = false;
    }
    public void PlayClick()
    {
        pressPlay = true;
        pressEdit = false;
    }
    public void Play()
    {
        EditorUI.SetActive(false);
        PlayUI.SetActive(true);
        Time.timeScale = 1f;
        
    }
    public void Edit()
    {
        EditorUI.SetActive(true);
        PlayUI.SetActive(false);
        Time.timeScale = 0f;
        
    }

    
}
