/*
==========================================
 Title: Don't Destroy
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

public class DontDestroy : MonoBehaviour
{
    // Do not destroy the object that has this script
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
