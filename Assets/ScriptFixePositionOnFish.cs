using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFixePositionOnFish : MonoBehaviour
{
    
    public Transform target; // Référence à l'objet cible
    public Vector2 offset; // Décalage pour ajuster la position exacte si besoin
    public bool goInFish = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (target != null && goInFish)
        {
            RectTransform targetRect = target.GetComponent<RectTransform>();

            if (targetRect != null)
            {
                // Calcule la position du coin supérieur gauche de l'objet cible
                Vector3 topLeftPosition = target.position + new Vector3(-targetRect.rect.width / 2, targetRect.rect.height / 2, 0);

                // Positionne l'objet `follower` sur le coin supérieur gauche de l'objet cible avec le décalage
                transform.position = topLeftPosition + (Vector3)offset;
            }
            else
            {
                Debug.LogWarning("L'objet cible n'a pas de RectTransform.");
            }
        }
    }
    public void SetOnFish(bool newValue){
        goInFish = newValue;
    }
}
