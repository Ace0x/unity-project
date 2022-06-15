/*
==========================================
 Title: Fighter
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

public class Fighter : MonoBehaviour {
    // Health information
    public int hitpoint = 10;
    public int maxHitpoint = 10;

    // Recovery speed after being hit
    public float pushRecoverySpeed = 0.2f;

    // Immunity after being hit
    protected float immuneTime = 1.0f;
    // Timestamp of when Fighter was first immune
    protected float lastImmune;

    // Direction Fighter is pushed when hit
    protected Vector3 pushDirection;

    // Function to recieve damage
    protected virtual void RecieveDamage(Damage dmg) {
        // Check if the Fighter is not immune anymore
        if (Time.time - lastImmune > immuneTime) {
            // Reset the lat time it was immune to current time
            lastImmune = Time.time;
            // Reduce hitpoints by the damage recieved
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            // Find the audio manager and play the recieve damage sound with it
            FindObjectOfType<AudioManager>().Play("RecieveDamage");

            // Visual effect for getting hit
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 20, 1.5f);

            // If HP reaches 0, call the Death() function
            if (hitpoint <= 0) {
                hitpoint = 0;
                Death();
            }
        }
    }

    // Function to die
    protected virtual void Death() {}
}
