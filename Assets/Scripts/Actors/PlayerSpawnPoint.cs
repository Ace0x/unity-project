/*
==========================================
 Title: Boss
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

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        if(GameObject.Find("SpawnPoint(Clone)") == null) // renames the object
        {
            gameObject.name = "SpawnPoint";
        }

        if(GameObject.Find("Player(Clone)") == null) // renames the player and sets it as a child
        {
            GameObject pl = GameObject.Instantiate(Player, transform.position, Quaternion.identity) as GameObject;
            pl.name = "Player";
            pl.transform.parent = gameObject.transform;
        }
        else
        {
            if(gameObject.name.Contains("SpawnPoint"))
            {
                GameObject.Find("Player").transform.parent = gameObject.transform; // gets an existing player and sets it as a child
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}