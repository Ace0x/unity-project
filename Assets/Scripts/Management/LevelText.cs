/*
==========================================
 Title: Level Text
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
using TMPro;

public class LevelText : GameManager {
    private TextMeshProUGUI textMesh;

    void Awake() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void AddExperience() {
        textMesh.text = "Lv. " + GameManager.instance.level;
    }
}