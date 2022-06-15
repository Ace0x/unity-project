/*
==========================================
 Title: Custom Tile
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
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Customtile", menuName = "LevelEditor/Tile")]//custom scripted tiles for automatic layer positioning
public class CustomTile : ScriptableObject //Custom Tiles for Level Builder
{
    public TileBase tile;
    public string id;
    public Level_Manager.Tilemaps tilemap;
}