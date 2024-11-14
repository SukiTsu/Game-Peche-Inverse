using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ScriptTrophee : MonoBehaviour
{
    private Dictionary<string, int> trophies = new Dictionary<string, int>();
    private List<KeyValuePair<string, int>> predefinedTrophies = new List<KeyValuePair<string, int>>()
    {
        new KeyValuePair<string, int>("Trophy1", 0),
        new KeyValuePair<string, int>("Trophy2", 0),
        new KeyValuePair<string, int>("Trophy3", 0),
        new KeyValuePair<string, int>("Trophy4", 0),
    };
    void Start()
    {
        LoadTrophies();
    }

    public void AddTrophy(string trophyName, int amount)
    {
        if (trophies.ContainsKey(trophyName))
        {
            trophies[trophyName] += amount;
        }
        else
        {
            Debug.Log("Trophé inexistant");
        }
        SaveTrophies(); // Sauvegarde le dictionnaire après modification
    }
    public void InitTrophies(){
        foreach (var trophy in predefinedTrophies)
        {
            trophies[trophy.Key] = trophy.Value;
        }
    }
    private void SaveTrophies()
    {
        string json = JsonConvert.SerializeObject(trophies);
        PlayerPrefs.SetString("TrophiesData", json);
        PlayerPrefs.Save();
    }

    // Charge le dictionnaire depuis PlayerPrefs
    private void LoadTrophies()
    {
        if (PlayerPrefs.HasKey("TrophiesData"))
        {
            string json = PlayerPrefs.GetString("TrophiesData");
            trophies = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }
    }
    public void toString(){
        foreach (var trophy in trophies)
        {
            Debug.Log(trophy.Key + ": " + trophy.Value);
        }
    }
}
