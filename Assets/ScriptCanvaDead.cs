using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCanvaDead : MonoBehaviour
{
    public MovePerso pecheur = null;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log("Mort du perso");
            canvaSetDead();
        }
    }

    public void canvaSetDead(){
        if (pecheur!=null){
            pecheur.setDead(true);
        }
    }

    public void restart(){
        if (pecheur!=null){
            pecheur.setDead(false);
            gameObject.SetActive(false);
        }
    }
}
