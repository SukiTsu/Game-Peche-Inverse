using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerso : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    public float jumpForce = 1f; // Force de saut

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private bool isPressingS = false;

    private Collider2D platTuch = null;

    private SpriteRenderer spriteRenderer = null;
    public bool isDead = false;
    private ScriptTrophee scriptTrophee;
    void Start()
    {
        // Récupère le composant Rigidbody2D attaché à ce GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isDead)
        {
            MouvPerso();
        }
    }

    public void setDead(bool dead){
        isDead = dead;
    }

    void MouvPerso(){
                // Déplacement horizontal
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Empêche de sauter à nouveau en l'air
        }

        isPressingS = Input.GetKey(KeyCode.S);
    }

    // Détection du contact avec le sol pour réinitialiser "isGrounded"
    void OnCollisionStay2D(Collision2D collision)
    {
        // Si le joueur touche un objet étiqueté comme "Sol" (ou ground en anglais)
        if (collision.gameObject.CompareTag("Sol") || collision.gameObject.CompareTag("PlatformeTraverssable"))
        {
            isGrounded = true;
            if(platTuch!=null){
                Debug.Log("Plateforme: "+platTuch);
            }
        }
        
        if (platTuch!=null){
            Debug.Log("retabli");
            Physics2D.IgnoreCollision(platTuch, GetComponent<Collider2D>(),false);
            Debug.Log("Plateforme: "+platTuch);
            platTuch = null;
        }
        
        // Si le joueur touche un objet étiqueté comme "PlatformeTraverssable" et appuie vers le bas
        if (collision.gameObject.CompareTag("PlatformeTraverssable") && isPressingS)
        {
            Debug.Log("au traver");
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            platTuch = collision.collider;
            Debug.Log("Plateforme: "+platTuch);
        }

        
    }

}