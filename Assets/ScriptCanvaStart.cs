using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCanvaStart : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame(){
        gameObject.SetActive(false);
        gameManager.StartGame();
    }
}
