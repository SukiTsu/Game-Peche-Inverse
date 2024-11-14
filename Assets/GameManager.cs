using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScriptTrophee trophyManager;

    public GameObject joueur;
    public GameObject hamson;

    void Start()
    {
        if (hamson!=null){
        hamson.SetActive(false);
        }
        if (joueur!=null){
        joueur.SetActive(false);
        }
        trophyManager = gameObject.AddComponent<ScriptTrophee>();
        
        trophyManager.InitTrophies();
        trophyManager.toString();
    }
    public void StartGame(){
        joueur.SetActive(true);
        hamson.SetActive(true);
    }
}
