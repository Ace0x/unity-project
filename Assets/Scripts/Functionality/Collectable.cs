/*
==========================================
 Title: Collectable
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

public class Collectable : Collidable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        // When it collides with the player, call OnCollect
        if (coll.name == "Player")
            OnCollect();
    }

    // Set collected as true when the player touches it
    protected virtual void OnCollect() {
        collected = true;
    }

    // Method to activate spells
    public virtual void Activate() {
        Debug.Log("Activate not configured.");
    }
}
