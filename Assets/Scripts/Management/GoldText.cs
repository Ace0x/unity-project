/*
==========================================
 Title: Gold Text
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

public class GoldText : GameManager {
    
    private TextMeshProUGUI textMesh;

    void Awake() {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void AddGold() {
        textMesh.text = "" + GameManager.instance.gold;
    }
}
