using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScriptCanvaDead : MonoBehaviour
{
    public MovePerso pecheur = null;
    public Image killerImage;   
    private bool isActive = false;      

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void canvaSetDead(GameObject killerObject){
        if (isActive) return;
        isActive = true;
        SpriteRenderer killerSpriteRenderer = killerObject.GetComponent<SpriteRenderer>();

        if (killerSpriteRenderer != null && killerImage != null)
        {
            // Change le sprite de l'image du Canvas pour correspondre à celui de l’objet
            killerImage.sprite = killerSpriteRenderer.sprite;
        }
        
        if (pecheur!=null){
            pecheur.setDead(true);
        }
        gameObject.SetActive(true);
    }

    public void restart(){
        if (pecheur!=null){
            isActive = false;
            pecheur.setDead(false);
            gameObject.SetActive(false);
        }
    }
}
