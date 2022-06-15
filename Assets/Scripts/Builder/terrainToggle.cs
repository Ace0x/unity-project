/*
==========================================
 Title: Terrain Toggle
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
//terrain toggle for editor
public class terrainToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public bool toggle = false;
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            toggle = !toggle;
        }
    }

    // Update is called once per frame
    public void ButtonClicked()
    {
        toggle = !toggle;
    }

}
