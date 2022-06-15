/*
==========================================
 Title: Show All Levels
 Authors: 
 Andrew Dunkerley, 
 Emiliano Cabrera, 
 Diego Corrales, 
 DO Hyun Nam
 Date: 14/06/2022
==========================================
*/

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;

[System.Serializable]
public class Level
{
    public int id;
    public string levelData;
    public int totalVictories;
    public int totalBosses;
    public int dislikes;
    public string name;
    public int userId;
    public int totalDeaths;
    public int totalEnemies;
    public int likes;
}

[System.Serializable]
public class leveling
{
    public List<Level> ls;
}


[System.Serializable]
public class Users
{
    public List<User> u;
}
public class showAllLevels : MonoBehaviour
{
    public List<Level> Levels;
    public static Level test;
    private string constring = "https://api-heavent.herokuapp.com/levels";
    bool load;
    public GameObject levelEntryItem;
    public Transform scroll;
    public leveling lsx;
    public Users users;
    public User usuario;

    private void Start()
    {
        load = true;
        LevelLoadRequest();
    }

    public void LevelLoadRequest()
    {
        StartCoroutine(GetLevels());
    }


    public IEnumerator GetLevels() //gets levels for level selector
    {
        using (UnityWebRequest www = UnityWebRequest.Get(constring))
        {
            
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
            {
                string raw = www.downloadHandler.text;
                string raw2 = "{ \"ls\":" + raw + "}";
                lsx = JsonUtility.FromJson<leveling>(raw2);            
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }

        using (UnityWebRequest www = UnityWebRequest.Get($"https://api-heavent.herokuapp.com/users"))
        {
        
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                if (www.downloadHandler.text != "null")
                {
                    string raw = www.downloadHandler.text; 
                    string raw2 = "{ \"u\":" + raw + "}";
                 
                    users = JsonUtility.FromJson<Users>(raw2);
                  
                }
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
        GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>().lvl = lsx.ls; //compares all ids in the user list to the current loaded level
                                                                                        //creator id to determine the corresponing username
        lsx.ls.Sort((x, y) => x.id.CompareTo(y.id));
        if (load)
            dislpayLevels(lsx.ls);
        load = false;
    }

    public void dislpayLevels(List<Level> levels) //displays all the obtained levels
    {
        for (int i = 0; i < levels.Count; i++)
        {
            GameObject displayItem = Instantiate(levelEntryItem, transform.position, Quaternion.identity);
            displayItem.transform.SetParent(scroll);
            displayItem.GetComponent<entryData>().lvlName = levels[i].name;
            displayItem.GetComponent<entryData>().lvlID = levels[i].id.ToString();
         
            for(int j = 0; j < users.u.Count; j++)
            {
                if (users.u[j].id == levels[i].userId)
                {
                    displayItem.GetComponent<entryData>().lvlCreator = users.u[j].username;
                    break;
                }
            }
            displayItem.GetComponent<entryData>().lvlData = levels[i].levelData;
            usuario = null;
        }
    }


}

