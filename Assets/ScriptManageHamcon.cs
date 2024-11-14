using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManageHamcon : MonoBehaviour
{
    private ScriptFixePositionOnFish scriptMouvOnFish;
    private ScriptMoveOnPecheur scriptMoveOnPecheur;
    private bool appelMov = false;

    void Start()
    {
        scriptMouvOnFish = GetComponent<ScriptFixePositionOnFish>();
        scriptMoveOnPecheur = GetComponent<ScriptMoveOnPecheur>();

        if (scriptMouvOnFish == null || scriptMoveOnPecheur == null)
        {
            Debug.Log("Erreur de chargement des scripts.");
        }

        scriptMoveOnPecheur.isMovingVertical = false;
    }

    void Update()
    {
        // Si le mouvement est terminé, fixe l'objet sur la position de la cible
        if (scriptMoveOnPecheur.mouvIsFinish && !appelMov)
        {
            scriptMouvOnFish.SetOnFish(true);
        }

        // Vérifie si la touche E est pressée une seule fois pour démarrer le mouvement
        if (Input.GetKeyDown(KeyCode.E) && !appelMov)
        {
            Debug.Log("Clique détecté");

            // Lance le mouvement et désactive la fixation
            scriptMouvOnFish.SetOnFish(false);
            appelMov = true;  // Marque que le mouvement a été déclenché
            scriptMoveOnPecheur.setMouv();  // Lance le mouvement vertical
        }

        // Réinitialise `appelMov` lorsque le mouvement est terminé
        if (scriptMoveOnPecheur.mouvIsFinish && appelMov)
        {
            appelMov = false;
        }
    }
}
