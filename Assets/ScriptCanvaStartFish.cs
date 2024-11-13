using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptCanvaStartFish : MonoBehaviour
{
    public float speed = 700f;
    public Vector3 direction = Vector3.right; // Direction du mouvement
    public float limiteLeft = 820;
    public float limiteRigt = -800;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        
        rectTransform.Translate(direction * speed * Time.deltaTime);

        // Exemple de limite de déplacement
        if (rectTransform.anchoredPosition.x > limiteLeft  || rectTransform.anchoredPosition.x < limiteRigt)
        {
            direction = -direction; // Inverse la direction
            Vector3 newScale = rectTransform.localScale;
            newScale.x *= -1;
            rectTransform.localScale = newScale;
        }
    }
}
