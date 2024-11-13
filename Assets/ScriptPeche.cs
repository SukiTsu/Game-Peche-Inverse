using UnityEngine;

public class MoveOverPlatform : MonoBehaviour
{
    public Transform target; // Cible pour le déplacement horizontal
    public float verticalDistance = 1f; // Distance verticale pour dépasser la plateforme
    public float verticalSpeed = 5f; // Vitesse de déplacement vertical
    public float horizontalSpeed = 5f; // Vitesse de déplacement horizontal
    public KeyCode actionKey = KeyCode.E; // Touche pour déclencher le mouvement

    private Rigidbody2D rb;
    private Collider2D col;

    private bool isMovingVertical = false;
    private bool isMovingHorizontal = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        // Vérifie si la touche spécifiée est enfoncée pour commencer le mouvement
        if (Input.GetKeyDown(actionKey) && !isMovingVertical && !isMovingHorizontal)
        {
            StartMovement();
        }

        // Gérer le déplacement horizontal si activé
        if (isMovingHorizontal)
        {
            MoveHorizontally();
        }
    }

    void OnCollisionEnter2D(Collision2D collition){
        if (collition.gameObject.CompareTag("Pecheur") || collition.gameObject.CompareTag("Sol")){
            Physics2D.IgnoreCollision(collition.collider, GetComponent<Collider2D>());
        }
    }

    void StartMovement()
    {
        // Désactive la gravité et les collisions
        rb.gravityScale = 0;
        col.enabled = false;

        // Active le mouvement vertical
        isMovingVertical = true;
        StartCoroutine(MoveUpward());
    }

    System.Collections.IEnumerator MoveUpward()
    {
        // Calcule la position cible en Y pour se déplacer au-dessus de la plateforme
        float targetY = transform.position.y + verticalDistance;

        // Déplace l'objet vers le haut jusqu'à atteindre la position cible en Y
        while (transform.position.y < targetY+5f)
        {
            transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
            yield return null;
        }

        // Passe au déplacement horizontal une fois le mouvement vertical terminé
        isMovingVertical = false;
        isMovingHorizontal = true;
    }

    void MoveHorizontally()
    {
        // Déplace l'objet vers la position cible en X seulement
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, horizontalSpeed * Time.deltaTime);

        // Vérifie si l'objet a atteint la position cible
        if (Mathf.Abs(transform.position.x - target.position.x) < 0.1f)
        {
            EndMovement();
        }
    }

    void EndMovement()
    {
        // Réactive la gravité et les collisions
        rb.gravityScale = 1;
        col.enabled = true;
        isMovingHorizontal = false;
    }
}
