using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptCanvaDead : MonoBehaviour
{
    public GameManager gameManagers;
    public Image killerImage;   
    void Start()
    {
    }

    void Update()
    {

    }

    public void canvaSetDead(GameObject killerObject){
        
        Debug.Log("Affiche canva");
        SpriteRenderer killerSpriteRenderer = killerObject.GetComponent<SpriteRenderer>();

        if (killerSpriteRenderer != null && killerImage != null)
        {
            // Change le sprite de l'image du Canvas pour correspondre à celui de l’objet
            killerImage.sprite = killerSpriteRenderer.sprite;
        }
        
        gameObject.SetActive(true);
        gameManagers.Pose();
        
    }

}
