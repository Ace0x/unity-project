/*
==========================================
 Title: Main Menu
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

public class MainMenu : MonoBehaviour
{
    //Main menu Scene Loader
    public void PlayGame() {
        SceneManager.LoadScene("LevelSelector");
    }

    public void BuildGame()
    {
        SceneManager.LoadScene("Editor");
    }

    public void MenuReturn() {
        SceneManager.LoadScene("Menu");
    }
}
