using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemie : MonoBehaviour
{
    public float speed = 2f;   // La vitesse de déplacement de l'IA
    private Rigidbody2D rb;    // Le Rigidbody2D de l'objet contrôlé par l'IA
    private bool movingRight = true;
    private float timetorotate = 5f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // Récupère le Rigidbody2D de l'objet contrôlé par l'IA
    }

    void FixedUpdate()
    {
        if (movingRight)    // Si l'IA se déplace vers la droite
        {
            // Ajoute une force horizontale vers la droite au Rigidbody2D
            rb.velocity = new Vector2(speed, rb.velocity.y);

            // Si l'objet contrôlé par l'IA atteint la limite de l'écran droit
            if (Time.time > timetorotate)
            {
                timetorotate = Time.time + 1f;
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;    // Change la direction de déplacement de l'IA
            }
        }
        else    // Si l'IA se déplace vers la gauche
        {
            // Ajoute une force horizontale vers la gauche au Rigidbody2D
            rb.velocity = new Vector2(-speed, rb.velocity.y);

            // Si l'objet contrôlé par l'IA atteint la limite de l'écran gauche
            if (Time.time > timetorotate)
            {
                timetorotate = Time.time + 1f;
                transform.Rotate(0f, -180f, 0f);
                movingRight = true;     // Change la direction de déplacement de l'IA
            }
        }
    }
    
}
