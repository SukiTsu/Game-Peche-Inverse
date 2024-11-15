using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ScriptTrophee trophyManager;

    public GameObject joueur;
    public ScriptManageHamcon hamson;
    public GameObject canvaStart;
    public GameObject canvaDead;
    public GameObject fish;
    public Vector3 targetPositionPecheur = new Vector3(1f, 3f, 0f);
    public Vector3 targetPositionFisch = new Vector3(1f, -2.6f, 0f);

    void Start()
    {
        
        if (joueur!=null){
        joueur.SetActive(false);
        }
        if (fish!=null){
            fish.SetActive(false);
        }
        
        trophyManager = gameObject.AddComponent<ScriptTrophee>();
        
        trophyManager.InitTrophies();
        trophyManager.toString();
        
    }
    public void StartGame(){
        joueur.SetActive(true);
        fish.SetActive(true);
        canvaStart.SetActive(false);
    }
    public void Pose(){
        joueur.SetActive(false);
        fish.SetActive(false);
    }
    public void Restart(){
        joueur.SetActive(true);
        fish.SetActive(true);
        canvaDead.SetActive(false);
        hamson.appelMov = false;

        joueur.transform.position = targetPositionPecheur;
        fish.transform.position = targetPositionFisch;
    }
}
