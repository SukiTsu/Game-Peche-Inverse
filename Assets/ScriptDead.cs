using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDead : MonoBehaviour
{

    public GameObject canvaDead = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pecheur") && canvaDead != null)
        {
           canvaDead.SetActive(true);        
        }
    }
}
