/*
==========================================
 Title: Delete Item
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

public class deleteItem : MonoBehaviour
{
    public int ID;
    private Level_Manager editor;
    private Scene currentScene;

    // Retrieve the name of this scene.
    string sceneName;

    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene(); 
        editor = GameObject.FindGameObjectWithTag("Manager").GetComponent<Level_Manager>();
        sceneName = currentScene.name;

    }
    //Deletes Items in the level editor on right click when hovered
    private void OnMouseOver()
    {
        if(sceneName == "Editor")
        {
            if (Input.GetMouseButtonDown(1) && this.gameObject.name.Contains("Player"))
            {
                Destroy(this.transform.parent.gameObject);
                editor.itemButtons[0].quantity++;
                editor.itemButtons[0].quantityText.text = editor.itemButtons[ID].quantity.ToString();
            }
                
            else if (Input.GetMouseButtonDown(1))
            {
                if (this.transform.parent.gameObject.name.Contains("SmallEnemy") || this.transform.parent.gameObject.name.Contains("Boss"))
                    Destroy(this.transform.parent.gameObject);
                else
                {
                    Destroy(this.gameObject);
                    editor.itemButtons[ID].quantity++;
                    editor.itemButtons[ID].quantityText.text = editor.itemButtons[ID].quantity.ToString();
                }
            }
        }
        
    }


}
