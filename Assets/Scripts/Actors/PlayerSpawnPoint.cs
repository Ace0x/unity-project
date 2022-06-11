using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("SpawnPoint(Clone)") == null)
        {
            gameObject.name = "SpawnPoint";
        }

        if(GameObject.Find("Player(Clone)") == null)
        {
            GameObject pl = GameObject.Instantiate(Player, transform.position, Quaternion.identity) as GameObject;
            pl.name = "Player";
            pl.transform.parent = gameObject.transform;
        }
        else
        {
            if(gameObject.name.Contains( "SpawnPoint"))
            {
                GameObject.Find("Player").transform.parent = gameObject.transform;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}