/*
==========================================
 Title: Healing Potion
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

public class HealingPotion : Collectable {
    public int hpAmount = 5;
    protected override void OnCollect() {
        // Remove the game object
        Destroy(gameObject);
        // Call Heal to heal the Player by hpAmount
        GameManager.instance.player.Heal(hpAmount);
        // Display the amount of HP gained on-screen
        GameManager.instance.ShowText("+ " + hpAmount + " HP", 25, Color.red, transform.position, Vector3.up * 20, 1.5f);
        // Find the audio manager and play the spell pickup sound with it
        FindObjectOfType<AudioManager>().Play("SpellPickup");
    }
}
