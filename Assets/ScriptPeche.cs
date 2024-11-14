using UnityEngine;

public class ScriptMoveOnPecheur : MonoBehaviour
{
    public Transform target; // Cible pour atteindre la hauteur
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical
    public float horizontalSpeed = 6f;
    public float hauteur = 2f;
    public bool mouvIsFinish = true;
    private bool isTop = false;
    public bool isMovingVertical = false;
    public bool isMovingHorizontal = false;
    private Rigidbody2D rb;
    private Collider2D col;
    private int numbTouchGroun = 0;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
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
        //col.enabled = false;
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
            col.enabled = true;
            rb.gravityScale = 1;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sol"))
        {
            if (numbTouchGroun == 0){
                Debug.Log("First tuch");
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
                numbTouchGroun +=1;
            }else{
                mouvIsFinish = true;
                Debug.Log("double tuch");
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(),false);

                numbTouchGroun = 0;
            }
        }
    }
}
