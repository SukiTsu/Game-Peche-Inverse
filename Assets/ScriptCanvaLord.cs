using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCanvaLord : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setVisibleNext(GameObject next){
        next.SetActive(true);
    }
    public void isEnd(GameObject canvaStart){
        gameObject.SetActive(false);
        canvaStart.SetActive(true);
    }
}
