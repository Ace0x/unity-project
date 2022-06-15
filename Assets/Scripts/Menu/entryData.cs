using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
==========================================
 Title: Entry Data
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 Do Hyun Nam
 Date: 14/06/2022
==========================================
*/
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class entryData : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI ID;
    public TextMeshProUGUI Creator;
    public string lvlData;
    public string lvlName;
    public string lvlID;
    public string lvlCreator;
    
    //Entry data to be displayed on level selector
    private void Start()//position on zeros so they display properly
    {
        transform.position = Vector3.zero;
        transform.localScale = new Vector3(1,1,1);
        nameText.text = lvlName;
        ID.text = lvlID;
        Creator.text = lvlCreator;
    }
   
    
}
