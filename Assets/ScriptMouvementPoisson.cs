using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMouvementPoisson : MonoBehaviour
{
    public Transform targetFish; 
    public float speed = 2f;
    private Vector3 originalScale;

    void Start(){
        originalScale = transform.localScale;
    }

    void Update()
    {
        onMouv();
    }
    void onMouv(){
        if (targetFish != null)
        {
        Vector3 currentPosition = transform.position;
        
        float newXPosition = Mathf.MoveTowards(currentPosition.x, targetFish.position.x, speed * Time.deltaTime);
        
        transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
        }

    }
}
