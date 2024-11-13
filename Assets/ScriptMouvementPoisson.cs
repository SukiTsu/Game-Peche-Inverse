using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMouvementPoisson : MonoBehaviour
{
    public Transform target; 
    public float speed = 2f;
    private Vector3 originalScale;

    void Start(){
        originalScale = transform.localScale;
    }

    void Update()
    {
    if (target != null)
    {
        Vector3 currentPosition = transform.position;
        
        float newXPosition = Mathf.MoveTowards(currentPosition.x, target.position.x, speed * Time.deltaTime);
        
        transform.position = new Vector3(newXPosition, currentPosition.y, currentPosition.z);
    

        if (newXPosition < currentPosition.x) // Se déplace vers la gauche
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (newXPosition > currentPosition.x) // Se déplace vers la droite
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
        }

    }
}
