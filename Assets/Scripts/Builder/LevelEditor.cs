/*
==========================================
 Title: Level Editor
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 DO Hyun Nam
 Date: 14/06/2022
==========================================
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class LevelEditor : MonoBehaviour
{

    [SerializeField] Tilemap defaultTilemap;
    public terrainToggle terrain;
    [SerializeField] public Image image;
    [SerializeField] public Sprite[] images;
    private string sceneName;
    Tilemap currentTilemap
    {
        //get current tile layer else return default
        get
        {
            if(Level_Manager.instance.layers.TryGetValue((int)Level_Manager.instance.tiles[selectedTileIndex].tilemap, out Tilemap tilemap))
            {
               
                return tilemap;
                
            }
            else
            {
                ;
                return defaultTilemap;
                
            }
            
        }
    }
    //get current tile
    TileBase currentTile
    {
        get
        {
            
            return Level_Manager.instance.tiles[selectedTileIndex].tile;
        }
    }
    
   
   [SerializeField] Camera cam;

    int selectedTileIndex;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    //tile placement based on mouse clicks
    private void Update() {
        //only works if current scene is the editor
        if (sceneName == "Editor")
        {
            Vector3Int pos = currentTilemap.WorldToCell(cam.ScreenToWorldPoint(Input.mousePosition));// get current mouse position on the screen


            if (terrain.toggle)
            {
                if (Input.GetMouseButton(0))
                {//pace tiles on current pos
                    PlaceTile(pos);
                }

                if (Input.GetMouseButton(1))
                {
                    DeleteTile(pos);
                }


                //select tiles with keyboard
                if (Input.GetKeyDown(KeyCode.Alpha1))//change chosen tiles
                {

                    selectedTileIndex++;
                    if (selectedTileIndex >= Level_Manager.instance.tiles.Count)
                        selectedTileIndex = 0;
                    image.sprite = images[selectedTileIndex];
                    Debug.Log(Level_Manager.instance.tiles[selectedTileIndex].name);
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))//
                {
                    selectedTileIndex--;
                    if (selectedTileIndex < 0)
                        selectedTileIndex = Level_Manager.instance.tiles.Count - 1;
                    image.sprite = images[selectedTileIndex];
                    //Debug.Log(Level_Manager.instance.tiles[selectedTileIndex].name);
                }
            }
        }

        }
    void PlaceTile(Vector3Int pos)
    {
       currentTilemap.SetTile(pos, currentTile);
    }

    void DeleteTile(Vector3Int pos)
    {
       currentTilemap.SetTile(pos, null);
    }
}
