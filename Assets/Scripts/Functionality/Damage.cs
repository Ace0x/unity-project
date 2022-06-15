/*
==========================================
 Title: Damage
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

public struct Damage
{
    // Position from where the damage came from
    public Vector3 origin;

    // Amount of damage done
    public int damageAmount;

    // Amount of knockback
    public float pushForce;


}
