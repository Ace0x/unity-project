using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;
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
public class showAllLevels : MonoBehaviour
{
    public List<Level> Levels;
    public static Level test;
    private string constring = "https://api-heavent.herokuapp.com/levels";
    bool load;
    public GameObject levelEntryItem;
    public Transform scroll;
    public leveling lsx;
    public User usuario;
    public List<User> usuarios = new List<User>();

    private void Start()
    {
        load = true;
        LevelLoadRequest();
    }

    public void LevelLoadRequest()
    {
        StartCoroutine(GetLevels());
    }

    public IEnumerator GetLevels()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(constring))
        {
            Levels = new List<Level>();
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
        GameObject.Find("Retain").gameObject.GetComponent<RetainOnLoad>().lvl = lsx.ls;

        List<Level> Sorted = lsx.ls.OrderBy(x => x.id).ToList();
        if (load)
            dislpayLevels(Sorted);
        load = false;
    }

    public void dislpayLevels(List<Level> levels)
    {

        for (int i = 0; i < levels.Count; i++)
        {
            StartCoroutine(Get(levels[i].userId, i, levels));
        }
        for(int i = 0; i < levels.Count; i++)
        {
            GameObject displayItem = Instantiate(levelEntryItem, transform.position, Quaternion.identity);
            displayItem.transform.SetParent(scroll);
            displayItem.GetComponent<entryData>().lvlName = levels[i].name;
            displayItem.GetComponent<entryData>().lvlID = levels[i].id.ToString();
            string username = "";
            for(int j = 0; j < usuarios.Count; j++)
            {
                if(usuarios[j].id == levels[i].userId)
                {
                    username = usuarios[j].username;
                    break;
                }
            }
            displayItem.GetComponent<entryData>().lvlCreator = username;
            displayItem.GetComponent<entryData>().lvlData = levels[i].levelData;
            usuario = null;
        }
    }

    IEnumerator Get(int user, int i, List<Level> levels)
    {
        using (UnityWebRequest www = UnityWebRequest.Get($"https://api-heavent.herokuapp.com/users/{user}"))
        {
            yield return www.SendWebRequest();
            
            if (www.result == UnityWebRequest.Result.Success)
            {
                if(www.downloadHandler.text != "null")
                {   
                    string raw = www.downloadHandler.text;
                    usuario = JsonUtility.FromJson<User>(raw);
                }
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }

            usuarios.Add(usuario);
        }

      
    }
}

