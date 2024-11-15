using UnityEngine;

public class ScriptMoveOnPecheur : MonoBehaviour
{
    public Transform target; // Cible pour atteindre la hauteur
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical
    public float horizontalSpeed = 6f;
    public float hauteur = 2f;
    public bool mouvIsFinish = true;
    private Collider2D sol = null;
    private bool isTop = false;
    public bool isMovingVertical = false;
    public bool isMovingHorizontal = false;
    private Rigidbody2D rb;
    private int numbTouchGroun = 0;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (isMovingVertical){
            MoveVerticallyToTargetHeight();
        }
        if (isTop && isMovingHorizontal){
            MoveHorizontallyToTargetHeight();
        }
    }
    public void setMouv(){
        isMovingVertical = true;
        rb.gravityScale = 0;
        mouvIsFinish = false;
    }

    public void MoveVerticallyToTargetHeight()
    {

        float targetY = target.position.y + hauteur;
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);
        // Déplace l'objet vers la position cible en Y
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, verticalSpeed * Time.deltaTime);
        // Vérifie si l'objet a atteint la même hauteur que la cible
        if (Mathf.Abs(transform.position.y - targetY) < 0.1f)
        {
            // Arrête le déplacement vertical une fois à la hauteur de la cible
            isMovingVertical = false;
            isMovingHorizontal = true;
            isTop = true;
            Physics2D.IgnoreCollision(sol, GetComponent<Collider2D>(),false);
        }
    
    }
    public void MoveHorizontallyToTargetHeight()
    {
        //Debug.Log("Demande de mouv vertical");

        // Déplace l'objet uniquement sur l'axe X vers la position X de la cible
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, horizontalSpeed * Time.deltaTime);
        // Vérifie si l'objet a atteint la même hauteur que la cible
        if (Mathf.Abs(transform.position.x - target.position.x) < 0.1f)
        {
            // Arrête le déplacement horizontal une fois à la hauteur de la cible
            isMovingHorizontal = false;
            rb.gravityScale = 1;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Traverse tout les objets avec le tag
        if (collision.gameObject.layer == LayerMask.NameToLayer("HamconTraverse")){
            Debug.Log("Layer travers");
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            
            // Stock le sol au premier contact
            if (collision.gameObject.CompareTag("Sol")){
                if(isMovingVertical){
                    sol = collision.collider;
                }else{
                    mouvIsFinish = true;
                }
            }
        }
    }
}
