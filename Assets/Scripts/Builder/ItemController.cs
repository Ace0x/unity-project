/*
==========================================
 Title: Item Controller
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

public class ItemController : MonoBehaviour
{
    

    public int ID;
    public int quantity;
    public TextMeshProUGUI quantityText;
    public bool clicked = false;
    public bool limited = false;
    private Level_Manager editor;

    void Start()
    {

        quantityText.text = quantity.ToString();
        editor = GameObject.FindGameObjectWithTag("Manager").GetComponent<Level_Manager>();

        
    }

    //Allows for placement of prefabs on the editor once the selected prefab is clicked and dropped
    public void ButtonClicked()
    {
        if(quantity > 0 && limited)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

            clicked = true;

            //in case the prefab has limited quantity it reduces the available items until they hit 0
            quantity--;
            quantityText.text = quantity.ToString();
            editor.currentButton = ID;
        }
        else if(!limited)
        {
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            clicked = true;
            editor.currentButton = ID;

        }
       
    }

    
}
