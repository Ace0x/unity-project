/*
==========================================
 Title: Faith Potion
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

public class FaithPotion : Collectable {

    public int faithAmount = 5;
    protected override void OnCollect() {
        // Remove the game object
        Destroy(gameObject);
        // Call Heal to heal the Player by hpAmount
        GameManager.instance.player.GainFaith(faithAmount);
        // Display the amount of HP gained on-screen
        GameManager.instance.ShowText("+ " + faithAmount + " Faith", 25, Color.blue, transform.position, Vector3.up * 20, 1.5f);
        // Find the audio manager and play the spell pickup sound with it
        FindObjectOfType<AudioManager>().Play("SpellPickup");
    }
}
