using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
   
    public float speed = 5f; // Vitesse de déplacement
    public float jumpForce = 10f; // Force de saut

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        // Récupère le composant Rigidbody2D attaché à ce GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Déplacement horizontal
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        // Saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false; // Empêche de sauter à nouveau en l'air
        }
    }

    // Détection du contact avec le sol pour réinitialiser "isGrounded"
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le joueur touche un objet étiqueté comme "Sol" (ou ground en anglais)
        if (collision.gameObject.CompareTag("Sol"))
        {
            isGrounded = true;
        }
    }
}
