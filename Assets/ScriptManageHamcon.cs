using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManageHamcon : MonoBehaviour
{
    private ScriptFixePositionOnFish scriptMouvOnFish;
    private ScriptMoveOnPecheur scriptMoveOnPecheur;
    private ScriptDead scriptDead;
    public bool appelMov = false;
    public float interval = 4f; 

    void Start()
    {
        scriptMouvOnFish = GetComponent<ScriptFixePositionOnFish>();
        scriptMoveOnPecheur = GetComponent<ScriptMoveOnPecheur>();
        scriptDead = GetComponent<ScriptDead>();

        if (scriptMouvOnFish == null || scriptMoveOnPecheur == null)
        {
            Debug.Log("Erreur de chargement des scripts.");
        }

        scriptMoveOnPecheur.isMovingVertical = false;
        InvokeRepeating("GoTrack", 3f, interval);

    }

    void Update()
    {
        // Si le mouvement est terminé, fixe l'objet sur la position de la cible
        if (scriptMoveOnPecheur.mouvIsFinish && !appelMov)
        {
            scriptMouvOnFish.SetOnFish(true);
        }

        // Réinitialise appelMov lorsque le mouvement est terminé
        if (scriptMoveOnPecheur.mouvIsFinish && appelMov)
        {
            appelMov = false;
        }
    }
    void GoTrack(){
        if (!appelMov)
        {
            interval = Random.Range(1.0f, 7.0f);
            scriptMouvOnFish.SetOnFish(false);
            appelMov = true; 
            scriptMoveOnPecheur.setMouv();  // Lance le mouvement vertical
        }
    }
}
