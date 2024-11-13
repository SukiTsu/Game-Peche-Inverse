using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCanvaStart : MonoBehaviour
{
    
public GameObject joueur;
public GameObject bot;

    void Start()
    {
        joueur.SetActive(false);
        bot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(){
        gameObject.SetActive(false);
        joueur.SetActive(true);
        bot.SetActive(true);
    }
}
