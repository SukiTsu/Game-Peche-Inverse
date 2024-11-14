using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class passageSceneNiv1 : MonoBehaviour
{
    // Fonction qui sera appelée pour charger la scène
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
